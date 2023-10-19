using FluentValidation;
using NoteAPI.DTOs.Collections;
using NoteAPI.DTOs.Notes;
using NoteAPI.Repositories;

namespace NoteAPI.Validators
{
    public class RequestValidators
    {
        private static bool IsValidGuid(Guid unValidatedGuid)
        {
            if (Guid.TryParse(unValidatedGuid.ToString(), out Guid validatedGuid))
            {
                return validatedGuid == Guid.Empty;
                  
            }
            else
            {
                return false;
            }

        }

        private static bool IsValidGuid(Guid? unValidatedGuid)
        {
            if (Guid.TryParse(unValidatedGuid.ToString(), out Guid validatedGuid))
            {
                return validatedGuid == Guid.Empty;
                
            }
            else
            {
                return false;
            }

        }

        public sealed class CreateNoteRequestValidator : AbstractValidator<CreateNoteRequest>
        {


            public CreateNoteRequestValidator()
            {
                RuleFor(c => c.CollectionId)
                    .Must(IsValidGuid)
                    .WithMessage("\'CollectionId\' section must be given valid Guid type ");
                    

                RuleFor(c => c.Title)
                    .NotNull()
                    .WithMessage(" \'Title\' section can not be null")
                    .NotEmpty()
                    .WithMessage(" \'Title\' section can not be empty or whitespace");


            }

            
        }

        public sealed class UpdateNoteRequestValidator : AbstractValidator<UpdateNoteRequest>
        {


            public UpdateNoteRequestValidator()
            {
                RuleFor(c => c.CollectionId)
                    .Must(IsValidGuid).When(d => d.CollectionId != null)
                    .WithMessage("You must provide valid Guid for collection Id");
               

                RuleFor(c => c.Title)
                    .NotEmpty().When(d => d.Title != null)
                    .WithMessage("\'Title\' section can not be empty or whitespace");

            }
        }

        public sealed class CreateCollectionRequestValidator : AbstractValidator<CreateCollectionRequest>
        {


            public CreateCollectionRequestValidator()
            {


                RuleFor(c => c.Title)
                    .NotNull()
                    .WithMessage(" \'Title\' section can not be null")
                    .NotEmpty()
                    .WithMessage(" \'Title\' section can not be empty or whitespace");


            }

        }
        public sealed class UpdateCollectionRequestValidator : AbstractValidator<UpdateCollectionRequest>
        {


            public UpdateCollectionRequestValidator()
            {

                RuleFor(c => c.Title)
                    .NotEmpty().When(d => d.Title != null)
                    .WithMessage(" \'Title\' section can not be empty or whitespace");
            }
        }


    }
}