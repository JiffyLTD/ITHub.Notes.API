using ITHub.Notes.DAL.DB.Context;
using ITHub.Notes.Domain.Entities;
using ITHub.Notes.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace ITHub.Notes.DAL.DB.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly AppDbContext _db;
        private readonly IMemoryCache _cache;

        public NoteRepository(AppDbContext db, IMemoryCache cache)
        {
            _db = db;
            _cache = cache;
        }

        public async Task<Note> TryCreateAsync(Note note)
        {
            var result = await _db.Notes.AddAsync(note);
            await _db.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Note> TryDeleteAsync(Guid id)
        {
            Note? note = await _db.Notes.FirstOrDefaultAsync(x => x.ID == id);

            var result = _db.Notes.Remove(note);
            await _db.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<List<Note>> TryGetAllAsync()
        {
            _cache.TryGetValue("noteList", out List<Note>? notes);

            if (notes != null)
            {
                return notes;
            }

            notes = await _db.Notes.ToListAsync();

            if (notes != null)
            {
                _cache.Set("noteList", notes, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));
            }

            return notes;
        }

        public async Task<Note> TryGetByIdAsync(Guid id)
        {
            _cache.TryGetValue(id, out Note? note);

            if (note != null)
            {
                return note;
            }

            note = await _db.Notes.FirstOrDefaultAsync(x => x.ID == id);

            if (note != null)
            {
                _cache.Set(note.ID, note, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));
            }

            return note;
        }

        public async Task<Note> TryUpdateAsync(Note note)
        {
            var result = _db.Notes.Update(note);
            await _db.SaveChangesAsync();

            return result.Entity;
        }
    }
}
