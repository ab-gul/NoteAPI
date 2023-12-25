using Azure.Core;
using Microsoft.EntityFrameworkCore;
using NoteAPI.Data;
using NoteAPI.Domain;
using NoteAPI.ExceptionHandling;
using NoteAPI.Pagination;
using NoteAPI.Repositories.Abstract;

namespace NoteAPI.Repositories.Concrete
{
    public class NoteRepository : BaseRepository<Note>, INoteRepository
        {
        public NoteRepository(AppDBContext context) : base(context)
        {
           // use the props of Paginationfilter directly. 
          
        }


        public async Task<List<Note>> GetAllNotesByCollectionIdAsync(Guid collectionId, PaginationFilter filter)
        {
            var skip = (filter.PageNumber - 1) * filter.PageSize;

            return await _entities.Where(n=> n.CollectionId == collectionId).Skip(skip).Take(filter.PageSize).ToListAsync();
        }

        public  Task<List<Note>> GetAllAsync(PaginationFilter filter)
        {
            var skip = (filter.PageNumber - 1) * filter.PageSize;

            return _entities.Skip(skip).Take(filter.PageSize).ToListAsync();
        }
    }


    
}