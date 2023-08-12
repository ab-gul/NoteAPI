namespace NoteAPI.DTOs.CollectionRequests
{
    public class CollectionRequest
    {
        public class GetCollectionRequest
        {
            public string? Title { get; set; }
            public string? Description { get; set; }
            public DateTime CreatedDate { get; set; }
        }
        public class UpdateCollectionRequest 
        {
            public string? Title { get; set; }
            public string? Description { get; set; }
            public DateTime CreatedDate { get; set; }


        }
        
    }
}
