using CollectionAPI.Repositories;
using NoteAPI.Data;
using NoteAPI.Domain;
using NoteAPI.Repositories;

namespace CollectionAPI.Services
{
    public class CollectionService : ICollectionService
    {
        private readonly ICollectionRepository collectionRepository;

        public CollectionService(ICollectionRepository collectionRepository)
        { 
        this.collectionRepository = collectionRepository; 
        }

        public async Task<Collection?> AddCollectionAsync(Collection newCollection)
        {
           await collectionRepository.AddCollectionAsync(newCollection);
           return await collectionRepository.GetCollectionByIdAsync(newCollection.ID);
      
        }

        public async Task DeleteCollectionAsync(Guid id)
        {
         await collectionRepository.DeleteCollectionAsync(id);
         
        }

        public async Task<List<Collection>> GetAllCollectionsAync()
        {
            return await collectionRepository.GetAllCollectionsAync();
        }

        public async Task<Collection?> GetCollectionByIdAsync(Guid id)
        {
            return await collectionRepository.GetCollectionByIdAsync(id);
        }

        public async Task UpdateCollectionAsync(Collection newCollection)
        {
            await collectionRepository.UpdateCollectionAsync(newCollection);
        }
    }
}
