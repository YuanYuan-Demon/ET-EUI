using Cinemachine;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class CameraComponent : Entity, IAwake, IUpdate
    {
        public Camera MainCamera;

        public CinemachineBrain BrainCamera;
        public CinemachineVirtualCamera VirtualCamera;
        public CinemachineFramingTransposer FramingTransposer;

        /// <summary>
        /// 摄像机与角色的距离
        /// </summary>
        public float CameraDistance = 10;

        /// <summary>
        /// 摄像机Y轴的旋转
        /// </summary>
        public float TargetYaw;

        /// <summary>
        /// 摄像机X轴的旋转
        /// </summary>
        public float TargetPitch = 45;

        public bool IsEnableRotate = false;
    }
}