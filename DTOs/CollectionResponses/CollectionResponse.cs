namespace NoteAPI.DTOs.CollectionResponses
{
    public class CollectionResponse
    {
        public class GetCollectionResponse 
        {
            public string? Title { get; set; }
            public string? Description { get; set; }
            public Guid Id { get; init; }
            public DateTime CreatedDate { get; set; }
        }
        public class UpdateCollectionResponse
        {
            public string? Title { get; set; }
            public string? Description { get; set; }
            public Guid Id { get; init; }
            public DateTime CreatedDate { get; set; }


        }
    }
}
