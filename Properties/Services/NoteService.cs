using NoteAPI.Data;
using NoteAPI.Models;
using NoteAPI.Repositories;

namespace NoteAPI.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository noteService;

        public NoteService(INoteRepository noteService)
        { 
        this.noteService = noteService; 
        }

        public async Task<Note?> AddNoteAsync(Note newNote)
        {
           await noteService.AddNoteAsync(newNote);
           return await noteService.GetNoteByIdAsync(newNote.Id);
      
        }

        public async Task DeleteNoteAsync(Guid id)
        {
         await noteService.DeleteNoteAsync(id);
         
        }

        public async Task<List<Note>> GetAllNotesAync()
        {
            return await noteService.GetAllNotesAync();
        }

        public async Task<Note?> GetNoteByIdAsync(Guid id)
        {
            return await noteService.GetNoteByIdAsync(id);
        }

        public async Task UpdateNoteAsync(Note newNote)
        {
            await noteService.UpdateNoteAsync(newNote);
        }
    }
}
