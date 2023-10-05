namespace ITHub.Notes.Domain.DTOs
{
    public class Response
    {
        public Response(string message, bool status)
        {
            Message = message;
            Status = status;
        }

        public Response(object? body, string message, bool status)
        {
            Items = body;
            Message = message;
            Status = status;
        }

        public object? Items { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
    }
}
