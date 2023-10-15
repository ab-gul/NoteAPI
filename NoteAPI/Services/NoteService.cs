﻿using CollectionAPI.Services;
using NoteAPI.Common.Extensions;
using NoteAPI.Data;
using NoteAPI.Domain;
using NoteAPI.DTOs.Notes;
using NoteAPI.ExceptionHandling;
using NoteAPI.Repositories.Abstract;
using NoteAPI.Repositories.Concrete;

namespace NoteAPI.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;
        private readonly ICollectionRepository _collectionRepository;


        public NoteService(INoteRepository noteRepository, ICollectionRepository collectionRepository)
        {
            _noteRepository = noteRepository;
            _collectionRepository = collectionRepository;
        }
        public async Task<Note> AddNoteAsync(Note newNote)
        {
            return await _collectionService.HasCollectionAsync(newNote.CollectionId)
                   ? await _noteRepository.AddAsync(newNote)
                   : throw new NotFoundException($"Collection with given Id : {newNote.CollectionId} does not exist!");
        }

        public async Task DeleteNoteAsync(Guid id)
        {
            await _noteRepository.DeleteAsync(id);
        }

        public async Task<List<Note>> GetAllNotesAync()
        {
             return await _noteRepository.GetAllAsync();

        }

        public async Task<Note?> GetNoteByIdAsync(Guid id)
        {
            return await _noteRepository.GetByIdAsync(id);
        }

        public async Task UpdateNoteAsync(Guid id,Note newNote)
        {
            //checking if note with given id exists

            var oldNote = await _noteRepository.GetByIdAsync(id);

            NotFoundException.ThrowIfNull(oldNote,id, nameof(Note));

            //
            // TODO add custom logic for title and description

            oldNote!.EditNote(new Note(
                newNote.CollectionId == Guid.Empty
                ? oldNote.CollectionId
                : (await _collectionService.HasCollectionAsync(newNote.CollectionId)
                            ? newNote.CollectionId
                            : throw new NotFoundException($"Collection with given Id:{newNote.CollectionId} does not exist!")),
                newNote.Title ?? oldNote.Title,
                newNote.Description ?? oldNote.Description!,
                newNote.UpdatedDate));

            await _noteRepository.UpdateAsync(oldNote);
            }
           
        }
    }

