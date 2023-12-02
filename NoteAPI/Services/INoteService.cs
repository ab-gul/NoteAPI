using NoteAPI.Domain;
using NoteAPI.DTOs.Notes;
using NoteAPI.Pagination;
using NoteAPI.Repositories;
using NoteAPI.Repositories.Abstract;

namespace NoteAPI.Services
{
    public interface INoteService 
    {

        Task<List<Note>> GetAllNotesAync(Guid? collectionId = null);
        Task<Note?> GetNoteByIdAsync(Guid id);
        Task<int> DeleteNoteAsync(Guid id);
        Task<Note> AddNoteAsync(Note newNote);
        Task UpdateNoteAsync(Guid id,Note newNote);
        Task<List<Note>> GetAllNotesByFilter(PaginationFilter filter);
    }
}
