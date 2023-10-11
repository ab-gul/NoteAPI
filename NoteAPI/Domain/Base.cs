using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoteAPI.Domain
{
    public abstract class Base
    {
        [Key]
        public Guid Id { get; protected set; }

        [Column("CREATED_AT")]
        public DateTime CreatedDate { get; protected set; }

        [Column("UPDATED_AT")]
        public DateTime UpdatedDate { get; protected set; }

    }
}
