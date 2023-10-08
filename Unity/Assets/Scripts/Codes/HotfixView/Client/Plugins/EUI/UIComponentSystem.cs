using System;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (ShowWindowData))]
    [FriendOf(typeof (UIPathComponent))]
    [FriendOf(typeof (UIBaseWindow))]
    [FriendOf(typeof (UIComponent))]
    public static class UIComponentSystem
    {
        /// <summary>
        ///     弹出并显示一个栈队列中的界面
        /// </summary>
        /// <param name="self"></param>
        private static void PopStackUIBaseWindow(this UIComponent self)
        {
            if (self.StackWindowsQueue.Count > 0)
            {
                var windowID = self.StackWindowsQueue.Dequeue();
                self.ShowWindow(windowID);
                var uiBaseWindow = self.GetUIBaseWindow(windowID);
                uiBaseWindow.IsInStackQueue = true;
            }
            else
            {
                self.IsPopStackWndStatus = false;
            }
        }

        /// <summary>
        ///     弹出并显示下一个栈队列中的界面
        /// </summary>
        /// <param name="self"></param>
        /// <param name="id"></param>
        private static void PopNextStackUIBaseWindow(this UIComponent self, WindowID id)
        {
            var uiBaseWindow = self.GetUIBaseWindow(id);
            if (uiBaseWindow != null && !uiBaseWindow.IsDisposed && self.IsPopStackWndStatus && uiBaseWindow.IsInStackQueue)
            {
                uiBaseWindow.IsInStackQueue = false;
                self.PopStackUIBaseWindow();
            }
        }

        private static UIBaseWindow ReadyToShowBaseWindow(this UIComponent self, WindowID id, ShowWindowData showData = null)
        {
            var baseWindow = self.GetUIBaseWindow(id);
            // 如果UI不存在开始实例化新的窗口
            if (null == baseWindow)
            {
                baseWindow = self.AddChild<UIBaseWindow>();
                baseWindow.WindowID = id;
                self.LoadBaseWindows(baseWindow);
            }

            if (!baseWindow.IsPreLoad)
                self.LoadBaseWindows(baseWindow);

            return baseWindow;
        }

        private static async ETTask<UIBaseWindow> ShowBaseWindowAsync(this UIComponent self, WindowID id, ShowWindowData showData = null)
        {
            CoroutineLock coroutineLock = null;
            try
            {
                coroutineLock = await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoadUIBaseWindows, (int)id);
                var baseWindow = self.GetUIBaseWindow(id);
                if (null == baseWindow)
                    if (UIPathComponent.Instance.WindowPrefabPath.ContainsKey(id))
                    {
                        baseWindow = self.AddChild<UIBaseWindow>();
                        baseWindow.WindowID = id;
                        await self.LoadBaseWindowsAsync(baseWindow);
                    }

                if (!baseWindow.IsPreLoad)
                    await self.LoadBaseWindowsAsync(baseWindow);

                return baseWindow;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                coroutineLock?.Dispose();
            }
        }

        private static void RealShowWindow(this UIComponent self, UIBaseWindow baseWindow, WindowID id, ShowWindowData showData = null)
        {
            baseWindow.UIPrefabGameObject?.SetActive(true);
            UIEventComponent.Instance.GetUIEventHandler(id).OnShowWindow(baseWindow, showData);

            self.VisibleWindowsDic[id] = baseWindow;
            Debug.Log("<color=magenta>### current Navigation window </color>" + baseWindow.WindowID);
        }

        /// <summary>
        ///     根据窗口Id获取UIBaseWindow
        /// </summary>
        /// <param name="self"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        private static UIBaseWindow GetUIBaseWindow(this UIComponent self, WindowID id) =>
                self.AllWindowsDic.TryGetValue(id, out var window)? window : null;

        /// <summary>
        ///     同步加载UI窗口实例
        /// </summary>
        private static void LoadBaseWindows(this UIComponent self, UIBaseWindow baseWindow)
        {
            if (!UIPathComponent.Instance.WindowPrefabPath.TryGetValue(baseWindow.WindowID, out var value))
            {
                Log.Error($"{baseWindow.WindowID} uiPath is not Exist!");
                return;
            }

            ResourcesComponent.Instance.LoadBundle(value.StringToAB());
            var go = ResourcesComponent.Instance.GetAsset(value.StringToAB(), value) as GameObject;
            baseWindow.UIPrefabGameObject = UnityEngine.Object.Instantiate(go);
            baseWindow.UIPrefabGameObject.name = go.name;

            UIEventComponent.Instance.GetUIEventHandler(baseWindow.WindowID).OnInitWindowCoreData(baseWindow);

            baseWindow?.SetRoot(EUIRootHelper.GetTargetRoot(baseWindow.windowType));
            baseWindow.uiTransform.SetAsLastSibling();

            UIEventComponent.Instance.GetUIEventHandler(baseWindow.WindowID).OnInitComponent(baseWindow);
            UIEventComponent.Instance.GetUIEventHandler(baseWindow.WindowID).OnRegisterUIEvent(baseWindow);

            self.AllWindowsDic[baseWindow.WindowID] = baseWindow;
        }

        /// <summary>
        ///     异步加载UI窗口实例
        /// </summary>
        private static async ETTask LoadBaseWindowsAsync(this UIComponent self, UIBaseWindow baseWindow)
        {
            if (!UIPathComponent.Instance.WindowPrefabPath.TryGetValue(baseWindow.WindowID, out var value))
            {
                Log.Error($"{baseWindow.WindowID} is not Exist!");
                return;
            }

            await ResourcesComponent.Instance.LoadBundleAsync(value.StringToAB());
            var go = ResourcesComponent.Instance.GetAsset(value.StringToAB(), value) as GameObject;
            baseWindow.UIPrefabGameObject = UnityEngine.Object.Instantiate(go);
            baseWindow.UIPrefabGameObject.name = go.name;

            UIEventComponent.Instance.GetUIEventHandler(baseWindow.WindowID).OnInitWindowCoreData(baseWindow);

            baseWindow?.SetRoot(EUIRootHelper.GetTargetRoot(baseWindow.windowType));
            baseWindow.uiTransform.SetAsLastSibling();

            UIEventComponent.Instance.GetUIEventHandler(baseWindow.WindowID).OnInitComponent(baseWindow);
            UIEventComponent.Instance.GetUIEventHandler(baseWindow.WindowID).OnRegisterUIEvent(baseWindow);

            self.AllWindowsDic[baseWindow.WindowID] = baseWindow;
        }

        public static void Awake(this UIComponent self)
        {
            self.IsPopStackWndStatus = false;
            self.AllWindowsDic?.Clear();
            self.VisibleWindowsDic?.Clear();
            self.StackWindowsQueue?.Clear();
            self.UIBaseWindowlistCached?.Clear();
        }

        /// <summary>
        ///     窗口是否是正在显示的
        /// </summary>
        /// <OtherParam name="id"></OtherParam>
        /// <returns></returns>
        public static bool IsWindowVisible(this UIComponent self, WindowID id) => self.VisibleWindowsDic.ContainsKey(id);

        /// <summary>
        ///     根据泛型获得UI窗口逻辑组件
        /// </summary>
        /// <param name="self"></param>
        /// <param name="isNeedShowState"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetDlgLogic<T>(this UIComponent self, bool isNeedShowState = false) where T : Entity, IUILogic
        {
            var windowsId = self.GetWindowIdByGeneric<T>();
            var baseWindow = self.GetUIBaseWindow(windowsId);
            if (null == baseWindow)
            {
                Log.Warning($"{windowsId} is not created!");
                return null;
            }

            if (!baseWindow.IsPreLoad)
            {
                Log.Warning($"{windowsId} is not loaded!");
                return null;
            }

            if (isNeedShowState)
                if (!self.IsWindowVisible(windowsId))
                {
                    Log.Warning($"{windowsId} is need show state!");
                    return null;
                }

            return baseWindow.GetComponent<T>();
        }

        /// <summary>
        ///     根据泛型类型获取窗口Id
        /// </summary>
        /// <param name="self"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static WindowID GetWindowIdByGeneric<T>(this UIComponent self) where T : Entity
        {
            if (UIPathComponent.Instance.WindowTypeIdDict.TryGetValue(typeof (T).Name, out var windowsId))
                return (WindowID)windowsId;

            Log.Error($"{typeof (T).FullName} is not have any windowId!");
            return WindowID.WindowID_Invaild;
        }

        /// <summary>
        ///     压入一个进栈队列界面
        /// </summary>
        /// <param name="self"></param>
        /// <typeparam name="T"></typeparam>
        public static void ShowStackWindow<T>(this UIComponent self) where T : Entity, IUILogic
        {
            var id = self.GetWindowIdByGeneric<T>();
            self.ShowStackWindow(id);
        }

        /// <summary>
        ///     压入一个进栈队列界面
        /// </summary>
        /// <param name="self"></param>
        /// <param name="id"></param>
        public static void ShowStackWindow(this UIComponent self, WindowID id)
        {
            self.StackWindowsQueue.Enqueue(id);

            if (self.IsPopStackWndStatus)
                return;

            self.IsPopStackWndStatus = true;
            self.PopStackUIBaseWindow();
        }

        /// <summary>
        ///     根据指定Id的显示UI窗口
        /// </summary>
        /// <OtherParam name="id"></OtherParam>
        /// <OtherParam name="showData"></OtherParam>
        public static void ShowWindow(this UIComponent self, WindowID id, ShowWindowData showData = null)
        {
            var baseWindow = self.ReadyToShowBaseWindow(id, showData);
            if (null != baseWindow)
                self.RealShowWindow(baseWindow, id, showData);
        }

        /// <summary>
        ///     根据泛型类型显示UI窗口
        /// </summary>
        /// <param name="self"></param>
        /// <param name="showData"></param>
        /// <typeparam name="T"></typeparam>
        public static void ShowWindow<T>(this UIComponent self, ShowWindowData showData = null) where T : Entity, IUILogic
        {
            var windowsId = self.GetWindowIdByGeneric<T>();
            self.ShowWindow(windowsId, showData);
        }

        /// <summary>
        ///     根据指定Id的异步加载显示UI窗口
        /// </summary>
        /// <param name="self"></param>
        /// <param name="id"></param>
        /// <param name="showData"></param>
        public static async ETTask ShowWindowAsync(this UIComponent self, WindowID id, ShowWindowData showData = null)
        {
            var baseWindow = self.GetUIBaseWindow(id);
            try
            {
                baseWindow = await self.ShowBaseWindowAsync(id, showData);
                if (null != baseWindow)
                    self.RealShowWindow(baseWindow, id, showData);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        /// <summary>
        ///     根据泛型类型异步加载显示UI窗口
        /// </summary>
        /// <param name="self"></param>
        /// <param name="showData"></param>
        /// <typeparam name="T"></typeparam>
        public static async ETTask ShowWindowAsync<T>(this UIComponent self, ShowWindowData showData = null) where T : Entity, IUILogic
        {
            var windowsId = self.GetWindowIdByGeneric<T>();
            await self.ShowWindowAsync(windowsId, showData);
        }

        /// <summary>
        ///     隐藏ID指定的UI窗口
        /// </summary>
        /// <OtherParam name="id"></OtherParam>
        /// <OtherParam name="onComplete"></OtherParam>
        public static void HideWindow(this UIComponent self, WindowID id)
        {
            if (!self.VisibleWindowsDic.ContainsKey(id))
            {
                Log.Warning($"检测关闭 WindowsID: {id} 失败！");
                return;
            }

            var baseWindow = self.VisibleWindowsDic[id];
            if (baseWindow == null || baseWindow.IsDisposed)
            {
                Log.Error($"UIBaseWindow is null  or isDisposed ,  WindowsID: {id} 失败！");
                return;
            }

            baseWindow.UIPrefabGameObject?.SetActive(false);
            UIEventComponent.Instance.GetUIEventHandler(id).OnHideWindow(baseWindow);

            self.VisibleWindowsDic.Remove(id);

            self.PopNextStackUIBaseWindow(id);
        }

        /// <summary>
        ///     根据泛型类型隐藏UI窗口
        /// </summary>
        /// <param name="self"></param>
        /// <typeparam name="T"></typeparam>
        public static void HideWindow<T>(this UIComponent self) where T : Entity
        {
            var hideWindowId = self.GetWindowIdByGeneric<T>();
            self.HideWindow(hideWindowId);
        }

        /// <summary>
        ///     卸载指定的UI窗口实例
        /// </summary>
        /// <OtherParam name="id"></OtherParam>
        public static void UnLoadWindow(this UIComponent self, WindowID id, bool isDispose = true)
        {
            var baseWindow = self.GetUIBaseWindow(id);
            if (null == baseWindow)
            {
                Log.Error($"UIBaseWindow WindowId {id} is null!!!");
                return;
            }

            UIEventComponent.Instance.GetUIEventHandler(id).BeforeUnload(baseWindow);
            if (baseWindow.IsPreLoad)
            {
                ResourcesComponent.Instance?.UnloadBundle(baseWindow.UIPrefabGameObject.name.StringToAB());
                UnityEngine.Object.Destroy(baseWindow.UIPrefabGameObject);
                baseWindow.UIPrefabGameObject = null;
            }

            if (isDispose)
            {
                self.AllWindowsDic.Remove(id);
                self.VisibleWindowsDic.Remove(id);
                baseWindow?.Dispose();
            }
        }

        /// <summary>
        ///     根据泛型类型卸载UI窗口实例
        /// </summary>
        /// <param name="self"></param>
        /// <typeparam name="T"></typeparam>
        public static void UnLoadWindow<T>(this UIComponent self) where T : Entity, IUILogic
        {
            var hideWindowId = self.GetWindowIdByGeneric<T>();
            self.UnLoadWindow(hideWindowId);
        }

        public static void Destroy(this UIComponent self) => self.CloseAllWindow();

        /// <summary>
        ///     根据窗口Id隐藏并完全关闭卸载UI窗口实例
        /// </summary>
        /// <param name="self"></param>
        /// <param name="windowId"></param>
        public static void CloseWindow(this UIComponent self, WindowID windowId)
        {
            if (!self.VisibleWindowsDic.ContainsKey(windowId))
                return;

            self.HideWindow(windowId);
            self.UnLoadWindow(windowId);
            Debug.Log("<color=magenta>## close window without PopNavigationWindow() ##</color>");
        }

        /// <summary>
        ///     根据窗口泛型类型隐藏并完全关闭卸载UI窗口实例
        /// </summary>
        /// <param name="self"></param>
        /// <typeparam name="T"></typeparam>
        public static void CloseWindow<T>(this UIComponent self) where T : Entity, IUILogic
        {
            var hideWindowId = self.GetWindowIdByGeneric<T>();
            self.CloseWindow(hideWindowId);
        }

        /// <summary>
        ///     关闭并卸载所有的窗口实例
        /// </summary>
        /// <param name="self"></param>
        public static void CloseAllWindow(this UIComponent self)
        {
            self.IsPopStackWndStatus = false;
            if (self.AllWindowsDic == null)
                return;

            foreach (var window in self.AllWindowsDic)
            {
                var baseWindow = window.Value;
                if (baseWindow == null || baseWindow.IsDisposed)
                    continue;

                self.HideWindow(baseWindow.WindowID);
                self.UnLoadWindow(baseWindow.WindowID, false);
                baseWindow?.Dispose();
            }

            self.AllWindowsDic.Clear();
            self.VisibleWindowsDic.Clear();
            self.StackWindowsQueue.Clear();
            self.UIBaseWindowlistCached.Clear();
        }

        /// <summary>
        ///     隐藏所有已显示的窗口
        /// </summary>
        /// <param name="self"></param>
        /// <param name="includeFixed"></param>
        public static void HideAllShownWindow(this UIComponent self, bool includeFixed = false)
        {
            self.IsPopStackWndStatus = false;
            self.UIBaseWindowlistCached.Clear();
            foreach (var window in self.VisibleWindowsDic)
            {
                if (window.Value.windowType == UIWindowType.Fixed && !includeFixed)
                    continue;

                if (window.Value.IsDisposed)
                    continue;

                self.UIBaseWindowlistCached.Add(window.Key);
                window.Value.UIPrefabGameObject?.SetActive(false);
                UIEventComponent.Instance.GetUIEventHandler(window.Value.WindowID).OnHideWindow(window.Value);
            }

            if (self.UIBaseWindowlistCached.Count > 0)
                for (var i = 0; i < self.UIBaseWindowlistCached.Count; i++)
                    self.VisibleWindowsDic.Remove(self.UIBaseWindowlistCached[i]);

            self.StackWindowsQueue.Clear();
        }

#region 生命周期

        [ObjectSystem]
        public class UIComponentAwakeSystem: AwakeSystem<UIComponent>
        {
            protected override void Awake(UIComponent self)
            {
                if (UIComponent.Instance == null)
                {
                    UIComponent.Instance = self;
                    self.Awake();
                }
                else
                {
                    Log.Error($"{nameof (UIComponent)} 已经存在, 在{UIComponent.Instance.Parent}中, 不应继续创建");
                }
            }
        }

        [ObjectSystem]
        public class UIComponentDestroySystem: DestroySystem<UIComponent>
        {
            protected override void Destroy(UIComponent self)
            {
                self.Destroy();
                UIComponent.Instance = null;
            }
        }

#endregion 生命周期
    }
}