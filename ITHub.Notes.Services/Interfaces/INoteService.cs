using ITHub.Notes.Domain.DTOs;
using ITHub.Notes.Domain.Entities;

namespace ITHub.Notes.Services.Interfaces
{
    public interface INoteService
    {
        public Task<Response> GetAllAsync();
        public Task<Response> GetByIdAsync(Guid id);
        public Task<Response> CreateAsync(NoteCreateDto noteDto);
        public Task<Response> UpdateAsync(NoteUpdateDto noteDto);
        public Task<Response> DeleteAsync(Note note);
    }
}
