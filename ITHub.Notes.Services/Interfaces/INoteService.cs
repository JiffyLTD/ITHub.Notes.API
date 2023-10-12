using ITHub.Notes.Domain.Entities;
using ITHub.Notes.Domain.Repositories.DTOs;

namespace ITHub.Notes.Services.Interfaces
{
    public interface INoteService
    {
        public Task<Response> GetAllAsync();
        public Task<Response> GetByIdAsync(Guid id);
        public Task<Response> CreateAsync(NoteCreateDto noteDto);
        public Task<Response> UpdateAsync(NoteUpdateDto noteDto);
        public Task<Response> DeleteAsync(Guid id);
    }
}
