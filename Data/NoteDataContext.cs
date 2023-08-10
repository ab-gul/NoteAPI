using Microsoft.EntityFrameworkCore;
using NoteAPI.Models;

namespace NoteAPI.Data
{
    public class NoteDataContext:DbContext
    {
        public NoteDataContext (DbContextOptions<NoteDataContext> options) : base(options) { }
     public DbSet<Note> Note { get; set;}
    }
}
