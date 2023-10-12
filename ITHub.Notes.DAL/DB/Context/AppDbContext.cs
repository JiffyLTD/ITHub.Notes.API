using ITHub.Notes.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ITHub.Notes.DAL.DB.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Note firstNote = new("Первая заметка", "Заметка была создана при инициализации бд");

            modelBuilder.Entity<Note>().HasData(firstNote);
        }
    }
}
