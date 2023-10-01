namespace NoteAPI.DTOs.Collections
{
    #region Requests
    public record GetCollectionRequest(string Title, string? Description, DateTime CreatedDate);
        
    public record UpdateCollectionRequest(string Title, string? Description);
        
    public record  CreateCollectionRequest(string Title, string? Description);
    
    #endregion

    #region Responses

    public record GetCollectionResponse(Guid Id, string Title, string? Description, DateTime CreatedDate, DateTime UpdatedDate);
    
    public record UpdateCollectionResponse(Guid Id, string Title, DateTime CreatedDate, DateTime UpdatedDate, string? Description);
    

    public record CreateCollectionResponse(Guid Id, string Title, DateTime CreatedDate);
    
    #endregion

    
}

