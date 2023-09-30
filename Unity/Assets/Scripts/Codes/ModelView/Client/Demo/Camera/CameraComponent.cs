using Cinemachine;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof (Scene))]
    public class CameraComponent: Entity, IAwake, IUpdate
    {
        public CinemachineBrain BrainCamera;

        /// <summary>
        ///     摄像机与角色的距离
        /// </summary>
        public float CameraDistance = 10;

        public CinemachineFramingTransposer FramingTransposer;

        public bool IsEnableRotate = false;
        public Camera MainCamera;

        /// <summary>
        ///     摄像机X轴的旋转
        /// </summary>
        public float TargetPitch = 45;

        /// <summary>
        ///     摄像机Y轴的旋转
        /// </summary>
        public float TargetYaw;

        public CinemachineVirtualCamera VirtualCamera;
    }
}