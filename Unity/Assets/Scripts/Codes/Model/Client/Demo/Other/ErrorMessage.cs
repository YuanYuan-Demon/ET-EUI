namespace ET.Client
{
    public class ErrorMessage: IResponse
    {
        [StaticField]
        public static readonly ErrorMessage Success = new(0, "Success");

        public ErrorMessage(int err = 0, string message = null)
        {
            this.Error = err;
            this.Message = message;
        }

        public int Error { get; set; }
        public string Message { get; set; }
        public int RpcId { get; set; }
    }
}