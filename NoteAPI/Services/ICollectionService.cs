using NoteAPI.Common;
using NoteAPI.Controllers;
using NoteAPI.Domain;
using NoteAPI.Repositories;
using NoteAPI.Repositories.Abstract;

namespace CollectionAPI.Services
{
    public interface ICollectionService 
    {
        Task<List<Collection>> GetAllCollectionsAync();
        Task<Collection?> GetCollectionByIdAsync(Guid id);
        Task DeleteCollectionAsync(Guid id);
        Task<Collection> AddCollectionAsync(Collection newCollection);
        Task UpdateCollectionAsync(Collection newCollection);
        Task<Collection?> GetCollectionByTitleAsync(string name);

    }
}
