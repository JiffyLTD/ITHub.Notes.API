using ITHub.Notes.Domain.Repositories.Interfaces;

namespace ITHub.Notes.DAL.DB.Interfaces
{
    public interface IUnitOfWork
    {
        public INoteRepository Notes { get; }
        public void SaveAsync();
    }
}
