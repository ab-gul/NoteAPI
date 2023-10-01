using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;

namespace NoteAPI.Domain
{
    public class Note : Base
    {
        [Column("FK_COLLECTION_ID")]
        public Guid CollectionId { get; set; }

        [Column("TITLE")]
        public string Title { get; set; } = null! ;

        [Column("DESCRIPTION")]
        public string? Description { get; set; }

        
    }
}
