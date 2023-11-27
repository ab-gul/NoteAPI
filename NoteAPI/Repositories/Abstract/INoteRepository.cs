using NoteAPI.Domain;

namespace NoteAPI.Repositories.Abstract;

public interface INoteRepository : IBaseRepository<Note>
{
    Task<List<Note>> GetAllNotesByFilter(int? paginationSize, int? paginationNumber);

    Task<List<Note>> GetAllNotesByCollectionIdAsync(Guid collectionId);
}







