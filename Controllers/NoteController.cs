using Microsoft.AspNetCore.Mvc;
using NoteAPI.Services;
using System.Runtime.CompilerServices;
using static NoteAPI.DTOs.NoteRequests.CollectionRequest;
using static NoteAPI.DTOs.NoteResponses.CollectionResponse;
using static NoteAPI.DTOs.NoteResponses.Response;

namespace NoteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteService noteService;
        public NoteController(INoteService noteController)
        {
            this.noteService = noteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNotesAsync()
        {
            List<GetNoteResponse> allNotes = new();

            var note = await noteService.GetAllNotesAync();

            foreach (var i in note)
            {
                allNotes.Add(new GetNoteResponse
                {
                    Description = i.Description,
                    Title = i.Title,
                    CreatedDate = i.CreatedDate
                });

            }
            return note.Any() ? Ok(note) : NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetNoteByIdAsync([FromRoute] Guid id)
        {
            var note = await noteService.GetNoteByIdAsync(id);

            return note != null ? Ok(new GetNoteResponse
            {
                Title = note.Title,
                CreatedDate = note.CreatedDate,
                Description = note.Description,
                Id = id

            }) : NoContent();

        }


        [HttpDelete]
        public async Task<IActionResult> DeleteNoteAsync([FromRoute] Guid id)
        {
            var note = await noteService.GetNoteByIdAsync(id);

            if (note != null) return NotFound($" The note with given id:{id} is not found");

            await noteService.DeleteNoteAsync(id);

            return NoContent();


        }
        [HttpPut]
        public async Task<IActionResult> UpdateNoteAsync([FromRoute] Guid id,
        [FromBody] UpdateNoteResponse newNote)
        {
            var note = await noteService.GetNoteByIdAsync(id);

            if (note != null) new GetNoteResponse
            {
                Title = note.Title,
                Description = note.Description,
                CreatedDate = note.CreatedDate,
                Id = id
            };
            return Ok(note);
        }





    }
}
