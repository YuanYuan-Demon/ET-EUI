using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ET.Client
{
    [FriendOfAttribute(typeof (ES_Joystick))]
    public static class ES_JoystickSystem
    {
        public static void RegisterUIEvent(this ES_Joystick self)
        {
            self.E_Bg_EventTrigger.RegisterEvent(EventTriggerType.PointerDown, self.OnJoyStickPointerDown);
            self.E_Bg_EventTrigger.RegisterEvent(EventTriggerType.PointerUp, self.OnJoyStickPointerUp);
            self.E_Bg_EventTrigger.RegisterEvent(EventTriggerType.Drag, self.OnJoyStickPointerMove);
            self.originPos = self.EI_Handle_Image.transform.localPosition;
        }

        public static void OnShow(this ES_Joystick self)
        {
            self.joyMoveTimerId = TimerComponent.Instance.NewFrameTimer(TimerInvokeType.JoyMoveTimer, self);
        }

        public static void OnHide(this ES_Joystick self)
        {
            TimerComponent.Instance.Remove(ref self.joyMoveTimerId);
        }

        private static Vector2 GetScaledDir(this ES_Joystick self, Vector2 dir)
        {
            return dir.normalized * (dir.x / self.Radius);
        }

        public static void OnJoyStickPointerDown(this ES_Joystick self, BaseEventData baseEventData)
        {
            var eventData = baseEventData as PointerEventData;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(self.E_Bg_EventTrigger.transform as RectTransform,
                eventData.position,
                eventData.pressEventCamera,
                out var localPos);

            self.moveDir = (localPos - self.originPos).normalized;
            var scale = self.moveDir.x / self.Radius;
            self.isUpdate = true;

            //修改位置
            self.EI_Handle_Image.transform.localPosition = localPos;

            var dir = new Vector3(self.moveDir.x, 0, self.moveDir.y).normalized;
            var camepos = Camera.main.transform.rotation * dir;
            var finalMoveDir = new Vector3(camepos.x, 0, camepos.z).normalized;
            self.ClientScene().CurrentScene().GetComponent<OperaComponent>().JoyMove(finalMoveDir);
            self.coolTime = 0;
        }

        public static void OnJoyStickPointerUp(this ES_Joystick self, BaseEventData baseEventData)
        {
            self.EI_Handle_Image.transform.localPosition = self.originPos;
            self.isUpdate = false;
            self.moveDir = Vector2.zero;
            self.coolTime = 0;
            self.ClientScene().CurrentScene().GetComponent<OperaComponent>().Stop();
        }

        public static void OnJoyStickPointerMove(this ES_Joystick self, BaseEventData baseEventData)
        {
            var eventData = baseEventData as PointerEventData;

            //拖拽的实现
            RectTransformUtility.ScreenPointToLocalPointInRectangle(self.E_Bg_EventTrigger.transform as RectTransform,
                eventData.position,
                eventData.pressEventCamera,
                out var localPos);
            var dir = localPos - self.originPos;
            if (dir.magnitude >= 128)
            {
                localPos = self.originPos + dir.normalized * 128;
            }

            self.moveDir = dir.normalized;

            //修改位置
            self.EI_Handle_Image.transform.localPosition = localPos;
        }

        private static void JoyMoveUpdate(this ES_Joystick self)
        {
            if (!self.isUpdate)
            {
                return;
            }

            if (self.moveDir == Vector2.zero)
            {
                self.lastDir = Vector2.zero;
                return;
            }

            self.coolTime += Time.deltaTime;
            var camepos = Camera.main.transform.rotation * new Vector3(self.moveDir.x, 0, self.moveDir.y);
            var finalMoveDir = new Vector3(camepos.x, 0, camepos.z).normalized;
            if (self.moveDir != self.lastDir)
            {
                if (self.coolTime >= 0.1f)
                {
                    self.ClientScene().CurrentScene().GetComponent<OperaComponent>().JoyMove(finalMoveDir);
                    self.coolTime = 0;
                }
            }
            else
            {
                if (self.coolTime >= 0.2f)
                {
                    self.ClientScene().CurrentScene().GetComponent<OperaComponent>().JoyMove(finalMoveDir);
                    self.coolTime = 0;
                }
            }

            self.lastDir = self.moveDir;
        }

        #region 定时任务

        [Invoke(TimerInvokeType.JoyMoveTimer)]
        public class JoyTimer: ATimer<ES_Joystick>
        {
            protected override void Run(ES_Joystick self)
            {
                try
                {
                    self.JoyMoveUpdate();
                }
                catch (Exception e)
                {
                    Log.Error($"移动定时器出错: [{self.Id}]\n{e}");
                }
            }
        }

        #endregion 定时任务
    }
}