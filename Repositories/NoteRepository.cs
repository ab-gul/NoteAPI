using Microsoft.EntityFrameworkCore;
using NoteAPI.Data;
using NoteAPI.Domain;

namespace NoteAPI.Repositories
{
    public class NoteRepository : INoteRepository
    {

        private readonly NoteDataContext context;
        public NoteRepository(NoteDataContext context) 
        {
         this.context = context;
        
        } 

        public  async Task AddNoteAsync(Note newNote)
        {
            context.Note.Add(newNote);
            await context.SaveChangesAsync();
        }

        public async Task DeleteNoteAsync(Guid id)
        {
            await context.Note.Where(note => note.Id == id).ExecuteDeleteAsync();

        }

        public async Task<List<Note>> GetAllNotesAync()
        {
            var notes =await context.Note.ToListAsync();
            return notes;
        }

        public async Task<Note?> GetNoteByIdAsync(Guid id)
        {
          var note = await context.Note.Where(note=> note.Id == id).FirstOrDefaultAsync();
            return note;
        }

        public async Task UpdateNoteAsync(Note newNote)
        {
            var note1 = await context.Note.Where(note => note.Id == newNote.Id).FirstOrDefaultAsync();
           
            note1 = new Note
                (
                 id: newNote.Id,
                 title: newNote.Title,
                 description: newNote.Description,
                 createdDate: newNote.CreatedDate               
                );

            await context.SaveChangesAsync();
        }

        
    }
}