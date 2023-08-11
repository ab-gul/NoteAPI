using NoteAPI.Data;
using NoteAPI.Models;
using NoteAPI.Repositories;

namespace NoteAPI.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository noteRepository;

        public NoteService(INoteRepository noteRepository)
        { 
        this.noteRepository = noteRepository; 
        }

        public async Task<Note?> AddNoteAsync(Note newNote)
        {
           await noteRepository.AddNoteAsync(newNote);
           return await noteRepository.GetNoteByIdAsync(newNote.Id);
      
        }

        public async Task DeleteNoteAsync(Guid id)
        {
         await noteRepository.DeleteNoteAsync(id);
         
        }

        public async Task<List<Note>> GetAllNotesAync()
        {
            return await noteRepository.GetAllNotesAync();
        }

        public async Task<Note?> GetNoteByIdAsync(Guid id)
        {
            return await noteRepository.GetNoteByIdAsync(id);
        }

        public async Task UpdateNoteAsync(Note newNote)
        {
            await noteRepository.UpdateNoteAsync(newNote);
        }
    }
}
