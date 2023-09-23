// ReSharper disable once RedundantUsingDirective

using System;
using System.Collections.Generic;

namespace ET
{
    public interface IConfigCategory
    {
        void Resolve(Dictionary<Type, IConfigSingleton> tables);
    }

    public interface IConfigSingleton: IConfigCategory, ISingleton
    {
    }

    public abstract class ConfigSingleton<T>: IConfigSingleton where T : ConfigSingleton<T>
    {
        private bool isDisposed;

        [StaticField]
        private static T instance;

        public static T Instance => instance ??= ConfigComponent.Instance.LoadOneConfig(typeof (T)) as T;

        void ISingleton.Register()
        {
            if (instance != null)
            {
                throw new($"singleton register twice! {typeof (T).Name}");
            }

            instance = (T)this;
        }

        void ISingleton.Destroy()
        {
            if (this.isDisposed)
            {
                return;
            }

            this.isDisposed = true;
            T t = instance;
            instance = null;
            t.Dispose();
        }

        public bool IsDisposed() => this.isDisposed;

        public virtual void Dispose()
        {
        }

        public virtual void TrimExcess()
        {
        }

        public virtual string ConfigName() => string.Empty;
        public abstract void Resolve(Dictionary<Type, IConfigSingleton> tables);
    }
}