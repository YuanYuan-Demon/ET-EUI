namespace ET.Luban
{
    public abstract class BeanBase: ITypeId
    {
        public abstract int GetTypeId();

        protected virtual void PostInit()
        {
        }

        protected virtual void PostResolve()
        {
        }
    }
}