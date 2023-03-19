namespace ET.Client
{
    public record ErrorMessage
    {
        public int Code;
        public string Message;
        [StaticField]
        public readonly static ErrorMessage Success = new(0, "Success");
        public ErrorMessage(int code = 0, string message = null)
        {
            Code = code;
            Message = message;
        }
    }
}