namespace NoteAPI.DTOs.NoteResponses
{
    public class Response
    {
        public class GetNoteResponse 
        {
            public string? Title { get; set; }
            public string? Description { get; set; }
            public Guid Id { get; init; }
            public DateTime CreatedDate { get; set; }
        }
        public class UpdateNoteResponse
        {
            public string? Title { get; set; }
            public string? Description { get; set; }
            public Guid Id { get; init; }
            public DateTime CreatedDate { get; set; }


        }
    }
}
