using Microsoft.EntityFrameworkCore;
using NoteAPI.Domain;

namespace NoteAPI.Data
{
    public class NoteDataContext : DbContext
    {
        public NoteDataContext(DbContextOptions<NoteDataContext> options) : base(options) { }

        public DbSet<Note> Note { get; init; }

        public DbSet<Collection> Collection { get; init; }
    }
}
