﻿using Microsoft.AspNetCore.Mvc;
using NoteAPI.DTOs.Notes;
using NoteAPI.Services;
using NoteAPI.Domain;
using AutoMapper;
using Azure.Core;
using NoteAPI.Common;
using FluentValidation;
using FluentValidation.Results;
using FluentValidation.AspNetCore;
using NoteAPI.Mapping;

namespace NoteAPI.Controllers
{
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;
        private readonly IMapper _mapper;
        public NoteController(INoteService noteService, IMapper mapper)
        {
            _noteService = noteService;
            _mapper = mapper;
        }

        [HttpGet(ApiRoutes.Notes.GetAll)]
        public async Task<IActionResult> GetAllNotesAsync([FromQuery] PaginationFilter query)
        {

            var notes = await _noteService.GetAllNotesAync(10,2);

            var notesResponse = _mapper.Map<List<GetNoteResponse>>(notes);

            var paginationResponse = new PageResponse<GetNoteResponse>() ;

            return Ok(paginationResponse);
        }

        [HttpGet(ApiRoutes.Notes.Get)]
        public async Task<IActionResult> GetNoteByIdAsync([FromRoute] Guid id)
        {
            var note = await _noteService.GetNoteByIdAsync(id);

            return note != null
                ? Ok(_mapper.Map<GetNoteResponse>(note))
                : NotFound($"Note with given id: {id} does not exists!");
        }


        [HttpDelete(ApiRoutes.Notes.Delete)]
        public async Task<IActionResult> DeleteNoteAsync([FromRoute] Guid id)
        {
            var note = await _noteService.GetNoteByIdAsync(id);

            if (note == null) return NotFound($"Note with given id: {id} does not exists!");

            await _noteService.DeleteNoteAsync(id);

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

           
            var noteToUpdate = _mapper.Map<Note>(request);

            await _noteService.UpdateNoteAsync(id,noteToUpdate);

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


            var newNote = _mapper.Map<Note>(request);

            return Ok(_mapper.Map<CreateNoteResponse>(await _noteService.AddNoteAsync(newNote)));
        }



    }
}
