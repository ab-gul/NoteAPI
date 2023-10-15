using Microsoft.IdentityModel.Tokens;
using NoteAPI.DTOs.Collections;
using NoteAPI.DTOs.Notes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;

namespace NoteAPI.Domain
{
    public class Note : Base
    {
        [Column("FK_COLLECTION_ID")]
        public Guid CollectionId { get; private set; }

        [Column("TITLE")]
        public string Title { get; private set; } = null!;

        [Column("DESCRIPTION")]
        public string? Description { get; private set; }

        private Note() { }

        public Note(Guid id, Guid collectionId, string title, DateTime createdDate, DateTime updatedDate ,string? description = null)
        {
            this.Id = id;
            this.CollectionId = collectionId;
            this.Title = string.IsNullOrEmpty(title) ? "Unnamed" : title;
            this.Description = description;
            this.CreatedDate = createdDate;
            this.UpdatedDate = updatedDate;

        }


        public static explicit operator Note(CreateNoteRequest request)
        {

            return new Note
                 
               (
                 id: Guid.NewGuid(),
                 request.CollectionId,
                 request.Title,
                 DateTime.UtcNow,
                 DateTime.UtcNow,
                 request.Description

                );
          
            
        }

        public static explicit operator Note(UpdateNoteRequest request)
        {

            return new Note

            (
                Guid.Empty,
                request.CollectionId ?? Guid.Empty,
                request.Title,
                default(DateTime),
                DateTime.UtcNow,
                request.Description 
                ); 

            
        }



        public static explicit operator GetNoteResponse(Note note) 
        {
            return new GetNoteResponse(
                Id: note.Id,
                CollectionId: note.CollectionId,
                Title: note.Title,
                Description: note.Description,
                UpdatedAt: note.UpdatedDate,
                CreatedDate: note.CreatedDate);
        }



        public static explicit operator CreateNoteResponse(Note note)
        {
            return new CreateNoteResponse(
                Id: note.Id,
                CollectionId: note.CollectionId,
                Title: note.Title,
                Description: note.Description,
                CreatedDate: note.CreatedDate,
                UpdatedAt: note.UpdatedDate

                );

        }
        public static explicit operator UpdateNoteResponse(Note note)
        {
            return new UpdateNoteResponse(
                Id: note.Id,
                Title: note.Title,
                Description: note.Description,
                UpdatedDate: note.UpdatedDate
                );
        
        }
        

    }
}
