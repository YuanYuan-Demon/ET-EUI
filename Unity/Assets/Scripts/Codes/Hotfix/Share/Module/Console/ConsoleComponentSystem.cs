using System;
using System.Threading.Tasks;

namespace ET
{
    [FriendOf(typeof (ConsoleComponent))]
    [FriendOf(typeof (ModeContex))]
    public static class ConsoleComponentSystem
    {
        [ObjectSystem]
        public class ConsoleComponentAwakeSystem: AwakeSystem<ConsoleComponent>
        {
            protected override void Awake(ConsoleComponent self)
            {
                self.Load();

                self.Start().Coroutine();
            }
        }

        [ObjectSystem]
        public class ConsoleComponentLoadSystem: LoadSystem<ConsoleComponent>
        {
            protected override void Load(ConsoleComponent self) => self.Load();
        }

        public static void Load(this ConsoleComponent self)
        {
            self.Handlers.Clear();

            var types = EventSystem.Instance.GetTypes(typeof (ConsoleHandlerAttribute));

            foreach (var type in types)
            {
                var attrs = type.GetCustomAttributes(typeof (ConsoleHandlerAttribute), false);
                if (attrs.Length == 0)
                    continue;

                var consoleHandlerAttribute = (ConsoleHandlerAttribute)attrs[0];

                var obj = Activator.CreateInstance(type);

                var iConsoleHandler = obj as IConsoleHandler;
                if (iConsoleHandler == null)
                    throw new($"ConsoleHandler handler not inherit IConsoleHandler class: {obj.GetType().FullName}");
                self.Handlers.Add(consoleHandlerAttribute.Mode, iConsoleHandler);
            }
        }

        public static async ETTask Start(this ConsoleComponent self)
        {
            self.CancellationTokenSource = new();

            while (true)
            {
                try
                {
                    var modeContex = self.GetComponent<ModeContex>();
                    var line = await Task.Factory.StartNew(() =>
                    {
                        Console.Write($"{modeContex?.Mode ?? ""}> ");
                        return Console.In.ReadLine();
                    }, self.CancellationTokenSource.Token);

                    line = line.Trim();

                    switch (line)
                    {
                        case "":
                            break;
                        case "exit":
                            self.RemoveComponent<ModeContex>();
                            break;
                        default:
                        {
                            var lines = line.Split(" ");
                            var mode = modeContex == null? lines[0] : modeContex.Mode;

                            if (!self.Handlers.TryGetValue(mode, out var iConsoleHandler))
                            {
                                Log.Console($"not found command: {line}");
                                break;
                            }

                            if (modeContex == null)
                            {
                                modeContex = self.AddComponent<ModeContex>();
                                modeContex.Mode = mode;
                            }

                            await iConsoleHandler.Run(modeContex, line);
                            break;
                        }
                    }
                }
                catch (Exception e)
                {
                    Log.Console(e.ToString());
                }
            }
        }
    }
}