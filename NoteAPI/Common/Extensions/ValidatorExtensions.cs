using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace NoteAPI.Common.Extensions
{
    public static class ValidatorExtensions
    {
        public static void AddToModelState(this ValidationResult validationResult, ModelStateDictionary modelState) 
        {

            foreach (var error in validationResult.Errors)
            {
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }

        }
    }
}
