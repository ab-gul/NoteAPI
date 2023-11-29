using NoteAPI.Domain;
using NoteAPI.Pagination;

namespace NoteAPI.Repositories.Abstract;

public interface INoteRepository : IBaseRepository<Note>
{
    Task<List<Note>> GetAllNotesByFilter(PaginationFilter filter);
   

}







