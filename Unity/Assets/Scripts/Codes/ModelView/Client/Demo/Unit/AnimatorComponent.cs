using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    public enum MotionType
    {
        None,
        Idle,
        TMove,
        Jump,
        Atk1,
        Atk2,
        Skill1,
        Skill2,
        Skill3,
        BreakHurt,
        Die,
    }

    [ComponentOf(typeof(Unit))]
    public class AnimatorComponent : Entity, IAwake, IUpdate, IDestroy
    {
        public Dictionary<string, AnimationClip> animationClips = new Dictionary<string, AnimationClip>();
        public HashSet<string> Parameter = new HashSet<string>();

        public MotionType MotionType;
        public float MontionSpeed;
        public bool isStop;
        public float stopSpeed;
        public Animator Animator;
    }
}