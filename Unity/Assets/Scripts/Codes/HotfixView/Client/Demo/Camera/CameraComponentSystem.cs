using Cinemachine;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (CameraComponent))]
    public static class CameraComponentSystem
    {
        private static async void Init(this CameraComponent self)
        {
            self.MainCamera = Camera.main;

            self.BrainCamera = self.MainCamera.gameObject.AddComponent<CinemachineBrain>();
            self.VirtualCamera = self.MainCamera.gameObject.AddComponent<CinemachineVirtualCamera>();
            self.FramingTransposer = self.VirtualCamera.AddCinemachineComponent<CinemachineFramingTransposer>();

            var unit = self.GetMyUnit();

            var goComponent = unit.GetComponent<GameObjectComponent>();
            if (goComponent is null)
            {
                await unit.GetComponent<ObjectWait>().Wait<Wait_UnitAddGOComponent>();
                goComponent = unit.GetComponent<GameObjectComponent>();
            }

            var unitGO = goComponent.GameObject;
            self.VirtualCamera.Follow = unitGO.transform;
            self.VirtualCamera.LookAt = unitGO.transform;

            self.RotateCameraView();
            self.ScrollCameraView();
        }

        private static void ClampAngle(this ref float angle, float min, float max) =>
                //if (angle < -360)
                //{
                //    angle += 360;
                //}
                //if (angle > 360)
                //{
                //    angle -= 360;
                //}
                angle = Mathf.Clamp(angle % 360, min, max);

        public static void ScrollCameraView(this CameraComponent self)
        {
            self.CameraDistance -= Input.GetAxis("Mouse ScrollWheel") * 5f;
            self.CameraDistance = Mathf.Clamp(self.CameraDistance, 5, 20);
            self.FramingTransposer.m_CameraDistance =
                    Mathf.LerpAngle(self.FramingTransposer.m_CameraDistance, self.CameraDistance, Time.deltaTime * 10);
        }

        public static void RotateCameraView(this CameraComponent self)
        {
            var mouseX = Input.GetAxis("Mouse X") * 200;
            var mouseY = Input.GetAxis("Mouse Y") * 200;

            self.TargetYaw += mouseX * Time.deltaTime;
            self.TargetPitch -= mouseY * Time.deltaTime;

            self.TargetYaw.ClampAngle(float.MinValue, float.MaxValue);
            self.TargetPitch.ClampAngle(1, 80);

            var targetRotation = Quaternion.Euler(self.TargetPitch, self.TargetYaw, 0);
            self.MainCamera.transform.rotation = targetRotation;
        }

#region 生命周期

        [ObjectSystem]
        public class CameraComponentAwakeSystem: AwakeSystem<CameraComponent>
        {
            protected override void Awake(CameraComponent self) => self.Init();
        }

        [ObjectSystem]
        public class CameraComponentUpdateSystem: UpdateSystem<CameraComponent>
        {
            protected override void Update(CameraComponent self)
            {
                if (Input.GetMouseButtonDown(1))
                    if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
                        self.IsEnableRotate = true;

                if (Input.GetMouseButtonUp(1))
                    self.IsEnableRotate = false;

                if (self.IsEnableRotate)
                    self.RotateCameraView();

                if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
                    self.ScrollCameraView();
            }
        }

#endregion
    }
}