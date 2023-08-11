using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoteAPI.Models
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


        public Collection(Guid id, List<Note> Notes, string? Title, string? Description) => ( )
            //{id,  Notes,  Title, Description  } = { }
           // {
           // this .ID = id;
           // this .Notes = Notes;
           // this .Title = Title;
           // this .Description = Description;
                


           //}
    }
}
