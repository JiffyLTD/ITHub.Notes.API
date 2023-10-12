using ITHub.Notes.DAL.DB.Context;
using ITHub.Notes.DAL.DB.Interfaces;
using ITHub.Notes.DAL.DB.Repositories;
using ITHub.Notes.Domain.Repositories.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace ITHub.Notes.DAL.DB.UnitOfWork
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
