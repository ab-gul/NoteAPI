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
        public Guid CollectionId { get; }

        [Column("TITLE")]
        public string Title { get; } = null!;

        [Column("DESCRIPTION")]
        public string? Description { get; }

        public Note(Guid id, Guid collectionId, string title, DateTime createdDate, DateTime updatedDate ,string? description = null)
        {
            CollectionId = id;
            Title = title;
            Description = description;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
            CollectionId = collectionId;

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
                Guid.NewGuid(),
                Guid.NewGuid(),
                request.Title,
                DateTime.UtcNow,
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
