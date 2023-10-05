using ITHub.Notes.Domain.DTOs;
using ITHub.Notes.Domain.Entities;

namespace ITHub.Notes.Services.Interfaces
{
    public interface INoteService
    {
        public Task<Response> GetAllAsync();
        public Task<Response> GetByIdAsync(Guid id);
        public Task<Response> CreateAsync(NoteDtoToCreate noteDto);
        public Task<Response> UpdateAsync(NoteDtoToUpdate noteDto);
        public Task<Response> DeleteAsync(Note note);
    }
}
