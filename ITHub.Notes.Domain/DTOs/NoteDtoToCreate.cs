namespace ITHub.Notes.Domain.DTOs
{
    public class NoteDtoToCreate
    {
        public NoteDtoToCreate() { }

        public NoteDtoToCreate(string? title, string? content)
        {
            Title = title;
            Content = content;
        }

        public string? Title { get; set; }
        public string? Content { get; set; }
    }
}
