namespace ET
{
    public static class SessionHelper
    {
        public static ETTask<IResponse> Call(Scene scene, IRequest request)
        {
            return scene.GetSession().Call(request);
        }

        public static Session GetSession(this Scene self)
        {
            return self.GetComponent<SessionComponent>().Session;
        }
    }
}