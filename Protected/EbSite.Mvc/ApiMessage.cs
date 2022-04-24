namespace EbSite.Mvc
{
    public class ApiMessage<T> : ApiMessage
    {
        public T Data { get; set; }
    }
    public class ApiMessage
    {
        public string Message { get; set; }
        public bool Success { get; set; }

    }
}