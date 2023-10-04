namespace ET
{
    public partial class TaskTarget
    {
        public NTaskTarget ToNTaskTarget() => new(this);

        public static explicit operator NTaskTarget(TaskTarget t) => t.ToNTaskTarget();
    }

    public partial class NTaskTarget
    {
        public NTaskTarget()
        {
        }

        public NTaskTarget(TaskTarget taskTarget)
        {
            this.Count = taskTarget.Count;
            this.Type = taskTarget.Type;
            this.Target = taskTarget.TargetId;
        }
    }
}