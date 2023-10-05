namespace ITHub.Notes.Domain.DTOs
{
    public class NoteDtoToUpdate
    {
        public NoteDtoToUpdate() { }

        public NoteDtoToUpdate(Guid id, string? title, string? content)
        {
            ID = id;
            Title = title;
            Content = content;
        }

        public Guid? ID { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
    }
}
