using Microsoft.EntityFrameworkCore;
using NoteAPI.Domain;

namespace NoteAPI.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>(entity =>
            {
                entity.ToTable("Notes");

            });

            modelBuilder.Entity<Collection>(entity =>
            {
                entity.ToTable("Collections");
            });


        }

        public DbSet<Note> Notes { get; init; }

        public DbSet<Collection> Collections { get; init; }
    }
}
