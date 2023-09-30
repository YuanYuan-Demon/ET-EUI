namespace ET
{
    [FriendOf(typeof (NavmeshComponent))]
    public static class NavmeshComponentSystem
    {
        public static long Get(this NavmeshComponent self, string name)
        {
            long ptr;
            if (self.Navmeshs.TryGetValue(name, out ptr))
            {
                return ptr;
            }

            byte[] buffer = EventSystem.Instance.Invoke<NavmeshComponent.RecastFileLoader, byte[]>(new() { Name = name });
            if (buffer.Length == 0)
            {
                throw new($"no nav data: {name}");
            }

            ptr = Recast.RecastLoadLong(name.GetHashCode(), buffer, buffer.Length);
            self.Navmeshs[name] = ptr;

            return ptr;
        }

        public class AwakeSystem: AwakeSystem<NavmeshComponent>
        {
            protected override void Awake(NavmeshComponent self) => NavmeshComponent.Instance = self;
        }
    }
}