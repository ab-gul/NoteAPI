using Microsoft.AspNetCore.Mvc;
using NoteAPI.DTOs.Notes;
using NoteAPI.Services;
using NoteAPI.Domain;
using NoteAPI.Common;
using NoteAPI.Common.Extensions;
using FluentValidation;
using FluentValidation.Results;
using NoteAPI.Pagination;

namespace NoteAPI.Controllers
{
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;
        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet(ApiRoutes.Notes.GetAll)]
        public async Task<IActionResult> GetAllNotesAsync([FromQuery] Guid? collectionId)
        {
            var notes =  await _noteService.GetAllNotesAync(collectionId)

            return Ok(notes.Select(note => (GetNoteResponse)note));

        }

        [HttpGet(ApiRoutes.Notes.GetFilteredNotes)]

        public async Task<IActionResult> GetNotesByFiltering([FromQuery] PaginationFilter filter)
        {

            var filteredPage = await _noteService.GetAllNotesByFilter(filter);

            return Ok(filteredPage);

        }


        [HttpGet(ApiRoutes.Notes.Get)]
        public async Task<IActionResult> GetNoteByIdAsync([FromRoute] Guid id)
        {
            var note = await _noteService.GetNoteByIdAsync(id);

            return note != null
                ? Ok((GetNoteResponse)note)
                : NotFound($"Note with given id: {id} does not exists!");
        }


        [HttpDelete(ApiRoutes.Notes.Delete)]
        public async Task<IActionResult> DeleteNoteAsync([FromRoute] Guid id)
        {
            var rowsDeleted = await _noteService.DeleteNoteAsync(id);

            if (rowsDeleted == 0) return NotFound($"Note with given id: {id} does not exists!");

            return NoContent();
        }

        [HttpPut(ApiRoutes.Notes.Update)]
        public async Task<IActionResult> UpdateNoteAsync([FromRoute] Guid id, [FromBody] UpdateNoteRequest request,
            [FromServices] IValidator<UpdateNoteRequest>? validator)
        {

            ArgumentException.ThrowIfNullOrEmpty(nameof(validator));

            ValidationResult validationResult = validator!.Validate(request);

            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(this.ModelState);

                return ValidationProblem();
            }


            var noteToUpdate = (Note)request;

            await _noteService.UpdateNoteAsync(id, noteToUpdate);

            return NoContent();

        }


        [HttpPost(ApiRoutes.Notes.Add)]
        public async Task<IActionResult> AddNoteAsync([FromBody] CreateNoteRequest request,
            [FromServices] IValidator<CreateNoteRequest>? validator)
        {

            ArgumentException.ThrowIfNullOrEmpty(nameof(validator));

            ValidationResult validationResult = validator!.Validate(request);

            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(this.ModelState);

                return ValidationProblem();
            }


            var newNote = (Note)request;

            var addedNote = await _noteService.AddNoteAsync(newNote);

            return Ok((CreateNoteResponse)addedNote);
        }




    }
}  

