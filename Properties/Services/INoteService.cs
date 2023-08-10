using NoteAPI.Models;
using NoteAPI.Repositories;

namespace NoteAPI.Services
{
    public interface INoteService
    {
      
        Task<List<Note>> GetAllNotesAync();
        Task<Note?> GetNoteByIdAsync(Guid id);
        Task DeleteNoteAsync(Guid id);
        Task<Note?> AddNoteAsync(Note newNote);
        Task UpdateNoteAsync(Note newNote);

    }
}
