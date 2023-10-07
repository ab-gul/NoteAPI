using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoteAPI.Domain
{
    public abstract class Base
    {
        [Key]
        public Guid Id { get; set; }

        [Column("CREATED_AT")]
        public DateTime CreatedDate { get; set; }

        [Column("UPDATED_AT")]
        public DateTime UpdatedDate { get; set; }

    }
}
