using NoteAPI.Domain;
using NoteAPI.DTOs.Notes;
using NoteAPI.Repositories;
using NoteAPI.Repositories.Abstract;

namespace NoteAPI.Services
{
    public interface INoteService 
    {
        Task<List<Note>> GetAllNotesAync();
        Task<Note?> GetNoteByIdAsync(Guid id);
        Task DeleteNoteAsync(Guid id);
        Task<Note> AddNoteAsync(Note newNote);
        Task UpdateNoteAsync(Guid id,Note newNote);


    }
}
