using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;

namespace NoteAPI.Domain
{
    public class Note
    {
        [Column("Title")]
        public string Title { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        [Key]
        public Guid Id { get;  }

        [Column("CreatedDate")]
        public DateTime CreatedDate { get; set; }
        

        public Note(string title, string description, Guid id, DateTime createdDate) 
        {
            Title = title;
            Description = description;
            Id = id;
            CreatedDate = createdDate;
  
        }

        
    }
}
