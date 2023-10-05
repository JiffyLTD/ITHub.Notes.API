namespace ITHub.Notes.Domain.Entities
{
    public class Note
    {
        public Note(string? title, string? content)
        {
            ID = Guid.NewGuid();
            Title = title;
            Content = content;
            CreatedAt = DateTime.Now.ToUniversalTime();
            UpdatedAt = DateTime.Now.ToUniversalTime();
        }

        public Guid ID { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
