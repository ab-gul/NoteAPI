using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoteAPI.Domain
{
    public class Collection : Base
    {
        [Column("TITLE")]
        public string Title { get; set; } = null!;

        [Column("DESCRIPTION")]
        public string? Description { get; set; } 

    }
}
