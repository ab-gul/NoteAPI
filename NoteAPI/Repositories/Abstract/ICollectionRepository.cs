using NoteAPI.Domain;

namespace NoteAPI.Repositories.Abstract
{
    public interface ICollectionRepository : IBaseRepository<Collection> 
    {
       Task<Collection?> GetCollectionByTitleAsync(string title);

       Task<bool> HasCollectionAsync(Guid id);


    }
}
