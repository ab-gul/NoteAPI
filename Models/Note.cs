using System.Security.AccessControl;

namespace NoteAPI.Models
{
    public class Note
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid Id { get;  }
        public DateTime CreatedDate { get; set; }

        public Note(string title, string description, Guid id, DateTime createdDate) 
        {
            Title = title;
            Description = description;
            Id = id;
            CreatedDate = createdDate;
  
        }

        internal Task GetNoteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
