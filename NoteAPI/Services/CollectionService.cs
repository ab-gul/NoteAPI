using NoteAPI.Data;
using NoteAPI.Domain;
using NoteAPI.ExceptionHandling;
using NoteAPI.Repositories;
using NoteAPI.Repositories.Abstract;
using NoteAPI.Repositories.Concrete;

namespace CollectionAPI.Services
{
    public class CollectionService : ICollectionService
    {
        private readonly ICollectionRepository _collectionRepository;

        public CollectionService(ICollectionRepository CollectionRepository)
        {
            _collectionRepository = CollectionRepository;
        }
        public async Task<Collection> AddCollectionAsync(Collection newCollection)
        {
            var collection = await _collectionRepository.GetCollectionByTitleAsync(newCollection.Title);

            DuplicateCollectionException.ThrowIfDublicate(collection, newCollection.Title);

            return await _collectionRepository.AddAsync(newCollection);
        }

        public async Task<int> DeleteCollectionAsync(Guid id)
        {
           return await _collectionRepository.DeleteAsync(id);
        }

        public async Task<List<Collection>> GetAllCollectionsAync()
        {
            return await _collectionRepository.GetAllAsync();
        }

        public async Task<Collection?> GetCollectionByIdAsync(Guid id)
        {
            return await _collectionRepository.GetByIdAsync(id);
        }


        public async Task UpdateCollectionAsync(Collection newCollection)
        {
            await _collectionRepository.UpdateAsync(newCollection);
        }
        public async Task<Collection?> GetCollectionByTitleAsync(string name)
        {
           return await _collectionRepository.GetCollectionByTitleAsync(name);
        }

        public async Task<bool> HasCollectionAsync(Guid id)
        {
           return await _collectionRepository.HasCollectionAsync(id);
        }
    }
}
