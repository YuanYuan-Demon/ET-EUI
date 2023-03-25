namespace ET.Server
{
    public static class TokenComponentSystem
    {
        private static async void AutoRemoveKey(this TokenComponent self, long key, string token)
        {
            await TimerComponent.Instance.WaitAsync(10 * TimeHelper.Minute);
            string onlineToken = self.Get(key);
            if (!string.IsNullOrEmpty(onlineToken) && onlineToken == token)
            {
                self.Remove(key);
            }
        }

        public static void Add(this TokenComponent self, long key, string token)
        {
            if (!self.Tokens.ContainsKey(key))
            {
                self.Tokens.Add(key, token);
                self.AutoRemoveKey(key, token);
            }
        }

        public static void AddOrModify(this TokenComponent self, long key, string token)
        {
            self.Tokens[key] = token;
            self.AutoRemoveKey(key, token);
        }

        public static string Get(this TokenComponent self, long key)
        {
            return self.Tokens.TryGetValue(key, out string token) ? token : null;
        }

        public static void Remove(this TokenComponent self, long key)
        {
            if (self.Tokens.ContainsKey(key))
            {
                self.Tokens.Remove(key);
            }
        }
    }
}