using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    public enum MotionType
    {
        None,
        Idle,
        Move,
        Jump,
        Atk1,
        Atk2,
        Skill1,
        Skill2,
        Skill3,
        BreakHurt,
        Die,
    }

    [ComponentOf(typeof (Unit))]
    public class AnimatorComponent: Entity, IAwake, IUpdate, IDestroy
    {
        public Dictionary<string, AnimationClip> animationClips = new();
        public Animator Animator;
        public bool isStop;
        public float MontionSpeed;

        public MotionType MotionType;
        public HashSet<string> Parameter = new();
        public float stopSpeed;
    }
}