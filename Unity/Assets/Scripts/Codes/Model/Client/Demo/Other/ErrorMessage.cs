namespace ET.Client
{
    public record ErrorMessage : IResponse
    {
        [StaticField]
        public readonly static ErrorMessage Success = new(0, "Success");

        public ErrorMessage(int err = 0, string message = null)
        {
            Error = err;
            Message = message;
        }

        public int Error { get; set; }
        public string Message { get; set; }
        public int RpcId { get; set; }
    }
}