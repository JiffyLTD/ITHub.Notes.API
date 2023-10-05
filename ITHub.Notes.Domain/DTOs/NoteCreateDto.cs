namespace ITHub.Notes.Domain.DTOs
{
    public class NoteCreateDto
    {
        public NoteCreateDto() { }

        public NoteCreateDto(string? title, string? content)
        {
            Title = title;
            Content = content;
        }

        public string? Title { get; set; }
        public string? Content { get; set; }
    }
}
