using Microsoft.EntityFrameworkCore;
using NoteAPI.Data;
using NoteAPI.Domain;

namespace CollectionAPI.Repositories
{
    public class CollectionRepository : ICollectionRepository
    {

        private readonly NoteDataContext context;
        public CollectionRepository(NoteDataContext context) 
        {
         this.context = context;
        
        } 

        public  async Task AddCollectionAsync(Collection newCollection)
        {
            context.Collection.Add(newCollection);
            await context.SaveChangesAsync();
        }

        public async Task DeleteCollectionAsync(Guid id)
        {
            await context.Collection.Where(Collection => Collection.ID == id).ExecuteDeleteAsync();

        }

        public async Task<List<Collection>> GetAllCollectionsAync()
        {
            var Collections =await context.Collection.ToListAsync();
            return Collections;
        }

        public async Task<Collection?> GetCollectionByIdAsync(Guid id)
        {
          var collection = await context.Collection.Where(collection=> collection.ID == id).FirstOrDefaultAsync();
            return collection;
        }

        public async Task UpdateCollectionAsync(Collection newCollection)
        {
            var collection1 = await context.Collection.Where(collection => collection.ID == newCollection.ID).FirstOrDefaultAsync();
           
            collection1 = new Collection
                (
                 id: newCollection.ID,
                 notes: newCollection.Notes,
                 title: newCollection.Title,
                 description: newCollection.Description,
                 createdDate: newCollection.CreatedDate
                             
                );

            await context.SaveChangesAsync();
        }

        
    }
}