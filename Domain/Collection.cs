using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoteAPI.Domain
{
    public class Collection
    {
        [Key]
        public Guid ID { get; init; } = Guid.NewGuid();

        [Column("Notes")]
        public List<Note> Notes { get; set; } = new List<Note>();

        [Column("Title")]
        public string? Title { get; set; } = string.Empty;

        [Column("Description")]
        public string? Description { get; set; } = string.Empty;

        [Column("CreatedDate")]
        public DateTime CreatedDate { get; set; }


        public Collection(Guid id, List<Note> notes, string? title, string? description, DateTime createdDate) => 
           (id, notes, title, description, createdDate) = (ID, Notes, Title, Description, CreatedDate);
            


           
    }
}
