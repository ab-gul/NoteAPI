using NoteAPI.Domain;

namespace NoteAPI.DTOs.Notes
{
    #region Requests
    public record UpdateNoteRequest(Guid? CollectionId, string? Title, string? Description);

    public record CreateNoteRequest(Guid CollectionId,string Title, string? Description);


    #endregion

    #region Responses
    public record GetNoteResponse(Guid Id, Guid CollectionId, string Title, string? Description, DateTime CreatedDate, DateTime UpdatedAt);


    public record CreateNoteResponse(Guid Id, Guid CollectionId, string Title, string Description, DateTime CreatedDate, DateTime UpdatedAt);

    public record UpdateNoteResponse(Guid Id, string Title, string Description, DateTime UpdatedDate);
    
    #endregion
}
