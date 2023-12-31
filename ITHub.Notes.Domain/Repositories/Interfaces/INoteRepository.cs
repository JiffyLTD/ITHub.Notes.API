﻿using ITHub.Notes.Domain.Entities;

namespace ITHub.Notes.Domain.Repositories.Interfaces
{
    public interface INoteRepository
    {
        public Task<List<Note>> TryGetAllAsync();
        public Task<Note> TryGetByIdAsync(Guid id);
        public Task<Note> TryCreateAsync(Note note);
        public Task<Note> TryUpdateAsync(Note note);
        public Task<Note> TryDeleteAsync(Guid id);
    }
}
