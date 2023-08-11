namespace NoteAPI.DTOs.NoteRequests
{
    public class Request
    {
        public class GetNoteRequest
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime CreatedDate { get; set; }
        }
        public class UpdateNoteRequest 
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime CreatedDate { get; set; }


        }
        
    }
}
