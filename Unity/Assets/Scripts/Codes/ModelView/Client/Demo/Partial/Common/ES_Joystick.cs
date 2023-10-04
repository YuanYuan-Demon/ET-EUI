using UnityEngine;

namespace ET.Client
{
    public partial class ES_Joystick
    {
        public float coolTime;
        public bool isUpdate;
        public long joyMoveTimerId;
        public Vector2 lastDir;
        public Vector2 moveDir;
        public Vector2 originPos;
        public float Radius;
    }
}