using Microsoft.EntityFrameworkCore;
using NoteAPI.Data;
using NoteAPI.Domain;
using NoteAPI.Repositories.Abstract;

namespace NoteAPI.Repositories.Concrete
{
    public class CollectionRepository : BaseRepository<Collection>, ICollectionRepository 
    {
        public CollectionRepository(AppDBContext context): base(context) 
        {
            
        }

        public async Task<Collection?> GetCollectionByTitleAsync(string title)
        {
           return await  _entities.FirstOrDefaultAsync(c => c.Title == title);
            
        }

        public async Task<bool> HasCollectionAsync(Guid id)
        {
           return await _entities.AnyAsync(c  => c.Id == id);
        }
    }
}