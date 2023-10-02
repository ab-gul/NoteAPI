using NoteAPI.DTOs.Collections;
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



        public static explicit operator CreateCollectionResponse(Collection collection)
        {
            return new CreateCollectionResponse(

                Id: collection.Id,
                Title: collection.Title,
                CreatedDate: collection.CreatedDate

                );

        }

        public static explicit operator GetCollectionResponse(Collection collection)
        {
            return new GetCollectionResponse(
                Id: collection.Id,
                Title: collection.Title,
                Description: collection.Description,
                CreatedDate: collection.CreatedDate,
                UpdatedDate: collection.UpdatedDate

                );

        }

        public static explicit operator UpdateCollectionResponse(Collection collection)
        {
            return new UpdateCollectionResponse(

                Id: collection.Id,
                Title: collection.Title,
                CreatedDate: collection.CreatedDate,
                UpdatedDate: collection.UpdatedDate,
                Description: collection.Description

                );

        }

        public static explicit operator Collection(CreateCollectionRequest request)
        {
            return new Collection
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                UpdatedDate = DateTime.UtcNow,
                CreatedDate = DateTime.UtcNow
            };

        }

        public static explicit operator Collection(UpdateCollectionRequest request) 
        {
            return new Collection
            {
                Title = request.Title,
                Description = request.Description,
                UpdatedDate = DateTime.UtcNow,
            };
        
        }




    }

    }



    

