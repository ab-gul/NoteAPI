using Azure.Core;
using Microsoft.EntityFrameworkCore;
using NoteAPI.Data;
using NoteAPI.Domain;
using NoteAPI.ExceptionHandling;
using NoteAPI.Repositories.Abstract;

namespace NoteAPI.Repositories.Concrete
{
    public class NoteRepository : BaseRepository<Note>, INoteRepository
        {
        public NoteRepository(AppDBContext context) : base(context)
        {
           // use the props of Paginationfilter directly. 
          
        }

        public async Task<List<Note>> GetAllNotesByFilter(int? paginationSize, int? paginationNumber)
        {
            PaginationFilter paginationFilter = new PaginationFilter();

            var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;

            _entities.Skip(skip);
            return await _entities.Include(x=>x.Id).ToListAsync();

        }
    }


    
}