using NoteAPI.Domain;

namespace NoteAPI.Repositories
{
    public interface INoteRepository
    {
        Task<List<Note>> GetAllNotesAync();
        Task<Note?> GetNoteByIdAsync(Guid id);
        Task DeleteNoteAsync(Guid id);
        Task AddNoteAsync(Note newNote);
        Task UpdateNoteAsync(Note newNote);


    }
}
