namespace ITHub.Notes.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        public INoteRepository Notes { get; }
        public void SaveAsync();
    }
}
