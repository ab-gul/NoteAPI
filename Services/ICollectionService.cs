using NoteAPI.Domain;
using NoteAPI.Repositories;

namespace CollectionAPI.Services
{
    public interface ICollectionService
    {
      
        Task<List<Collection>> GetAllCollectionsAync();
        Task<Collection?> GetCollectionByIdAsync(Guid id);
        Task DeleteCollectionAsync(Guid id);
        Task<Collection?> AddCollectionAsync(Collection newCollection);
        Task UpdateCollectionAsync(Collection newCollection);

    }
}
