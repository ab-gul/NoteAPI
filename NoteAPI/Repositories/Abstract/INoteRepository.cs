using NoteAPI.Domain;
using NoteAPI.Pagination;

namespace NoteAPI.Repositories.Abstract;

public interface INoteRepository : IBaseRepository<Note>
{
    Task<List<Note>> GetAllAsync(PaginationFilter filter);
   
    Task<List<Note>> GetAllNotesByCollectionIdAsync(Guid collectionId, PaginationFilter filter);
}







