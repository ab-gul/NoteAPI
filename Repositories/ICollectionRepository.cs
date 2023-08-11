using NoteAPI.Domain;

namespace CollectionAPI.Repositories
{
    public interface ICollectionRepository
    {
        Task<List<Collection>> GetAllCollectionsAync();
        Task<Collection?> GetCollectionByIdAsync(Guid id);
        Task DeleteCollectionAsync(Guid id);
        Task AddCollectionAsync(Collection newCollection);
        Task UpdateCollectionAsync(Collection newCollection);


    }
}
