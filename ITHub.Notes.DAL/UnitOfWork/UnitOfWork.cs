using ITHub.Notes.DAL.Data;
using ITHub.Notes.DAL.Interfaces;
using ITHub.Notes.DAL.Repositories;
using Microsoft.Extensions.Caching.Memory;

namespace ITHub.Notes.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;
        private readonly IMemoryCache _cache;
        private NoteRepository? _noteRepository;

        public UnitOfWork(AppDbContext db, IMemoryCache cache)
        {
            _db = db;
            _cache = cache;
        }

        public INoteRepository Notes
        {
            get
            {
                if (_noteRepository == null)
                {
                    _noteRepository = new NoteRepository(_db, _cache);
                }

                return _noteRepository;
            }
        }

        public async void SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
