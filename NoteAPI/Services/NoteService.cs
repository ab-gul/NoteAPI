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
            //checking if collection with given id exists
           var collection = await _collectionRepository.GetByIdAsync(newNote.CollectionId);

            //if not throw custom exception
           NotFoundException.ThrowIfNull(collection, newNote.CollectionId, nameof(Collection));

           return await _noteRepository.AddAsync(newNote);
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

            var note = await _noteRepository.GetByIdAsync(id);

            NotFoundException.ThrowIfNull(note,id, nameof(Note));

            //
       

            if (newNote.CollectionId != Guid.Empty)
            {
                //checking if collection with given id exists
                var collection = await _collectionRepository.GetByIdAsync(newNote.CollectionId);

                //if not throw custom exception
                NotFoundException.ThrowIfNull(collection, newNote.CollectionId, nameof(Collection));

                //else
                var result = new Note(id, collectionId: newNote.CollectionId, title: newNote.Title, 
                    createdDate: newNote.CreatedDate, updatedDate: newNote.UpdatedDate);

                await _noteRepository.UpdateAsync(newNote);
                
                
                    
            };
                
            }
           
        }
    }

