using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof (DlgTask))]
    [EnableMethod]
    public class DlgTaskViewComponent: Entity, IAwake, IDestroy
    {
        private UnityEngine.UI.Button m_EB_Close_Button = null;
        private UnityEngine.UI.Image m_EB_Close_Image = null;
        private UnityEngine.UI.Image m_EL_BranchTask_Image = null;
        private UnityEngine.UI.LoopVList m_EL_BranchTask_LoopVList = null;
        private UnityEngine.UI.Image m_EL_MainTask_Image = null;
        private UnityEngine.UI.LoopVList m_EL_MainTask_LoopVList = null;
        private ES_TaskButton m_es_branchtask = null;
        private ES_TaskButton m_es_maintask = null;
        private ES_TaskInfo m_es_taskinfo = null;
        private UnityEngine.UI.Image m_ET_TaskList_Image = null;
        private UnityEngine.UI.ToggleGroup m_ET_TaskList_ToggleGroup = null;
        public Transform uiTransform = null;

        public UnityEngine.UI.Button EB_Close_Button
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EB_Close_Button == null)
                {
                    this.m_EB_Close_Button = UIHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject, "Panel/Title/EB_Close");
                }

                return this.m_EB_Close_Button;
            }
        }

        public UnityEngine.UI.Image EB_Close_Image
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EB_Close_Image == null)
                {
                    this.m_EB_Close_Image = UIHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject, "Panel/Title/EB_Close");
                }

                return this.m_EB_Close_Image;
            }
        }

        public UnityEngine.UI.ToggleGroup ET_TaskList_ToggleGroup
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_ET_TaskList_ToggleGroup == null)
                {
                    this.m_ET_TaskList_ToggleGroup =
                            UIHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject, "Panel/ET_TaskList");
                }

                return this.m_ET_TaskList_ToggleGroup;
            }
        }

        public UnityEngine.UI.Image ET_TaskList_Image
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_ET_TaskList_Image == null)
                {
                    this.m_ET_TaskList_Image = UIHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject, "Panel/ET_TaskList");
                }

                return this.m_ET_TaskList_Image;
            }
        }

        public ES_TaskButton ES_MainTask
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_es_maintask == null)
                {
                    Transform subTrans = UIHelper.FindDeepChild<Transform>(this.uiTransform.gameObject, "Panel/ET_TaskList/ES_MainTask");
                    this.m_es_maintask = this.AddChild<ES_TaskButton, Transform>(subTrans);
                }

                return this.m_es_maintask;
            }
        }

        public UnityEngine.UI.Image EL_MainTask_Image
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EL_MainTask_Image == null)
                {
                    this.m_EL_MainTask_Image =
                            UIHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject, "Panel/ET_TaskList/EL_MainTask");
                }

                return this.m_EL_MainTask_Image;
            }
        }

        public UnityEngine.UI.LoopVList EL_MainTask_LoopVList
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EL_MainTask_LoopVList == null)
                {
                    this.m_EL_MainTask_LoopVList =
                            UIHelper.FindDeepChild<UnityEngine.UI.LoopVList>(this.uiTransform.gameObject, "Panel/ET_TaskList/EL_MainTask");
                }

                return this.m_EL_MainTask_LoopVList;
            }
        }

        public ES_TaskButton ES_BranchTask
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_es_branchtask == null)
                {
                    Transform subTrans = UIHelper.FindDeepChild<Transform>(this.uiTransform.gameObject, "Panel/ET_TaskList/ES_BranchTask");
                    this.m_es_branchtask = this.AddChild<ES_TaskButton, Transform>(subTrans);
                }

                return this.m_es_branchtask;
            }
        }

        public UnityEngine.UI.Image EL_BranchTask_Image
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EL_BranchTask_Image == null)
                {
                    this.m_EL_BranchTask_Image =
                            UIHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject, "Panel/ET_TaskList/EL_BranchTask");
                }

                return this.m_EL_BranchTask_Image;
            }
        }

        public UnityEngine.UI.LoopVList EL_BranchTask_LoopVList
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_EL_BranchTask_LoopVList == null)
                {
                    this.m_EL_BranchTask_LoopVList =
                            UIHelper.FindDeepChild<UnityEngine.UI.LoopVList>(this.uiTransform.gameObject, "Panel/ET_TaskList/EL_BranchTask");
                }

                return this.m_EL_BranchTask_LoopVList;
            }
        }

        public ES_TaskInfo ES_TaskInfo
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                if (this.m_es_taskinfo == null)
                {
                    Transform subTrans = UIHelper.FindDeepChild<Transform>(this.uiTransform.gameObject, "Panel/TaskInfo/ES_TaskInfo");
                    this.m_es_taskinfo = this.AddChild<ES_TaskInfo, Transform>(subTrans);
                }

                return this.m_es_taskinfo;
            }
        }

        public void DestroyWidget()
        {
            this.m_EB_Close_Button = null;
            this.m_EB_Close_Image = null;
            this.m_ET_TaskList_ToggleGroup = null;
            this.m_ET_TaskList_Image = null;
            this.m_es_maintask?.Dispose();
            this.m_es_maintask = null;
            this.m_EL_MainTask_Image = null;
            this.m_EL_MainTask_LoopVList = null;
            this.m_es_branchtask?.Dispose();
            this.m_es_branchtask = null;
            this.m_EL_BranchTask_Image = null;
            this.m_EL_BranchTask_LoopVList = null;
            this.m_es_taskinfo?.Dispose();
            this.m_es_taskinfo = null;
            this.uiTransform = null;
        }
    }
}