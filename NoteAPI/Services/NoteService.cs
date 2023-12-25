using CollectionAPI.Services;
using NoteAPI.Common.Extensions;
using NoteAPI.Data;
using NoteAPI.Domain;
using NoteAPI.DTOs.Notes;
using NoteAPI.ExceptionHandling;
using NoteAPI.Pagination;
using NoteAPI.Repositories.Abstract;
using NoteAPI.Repositories.Concrete;
using System.Diagnostics.CodeAnalysis;


namespace NoteAPI.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;
        private readonly ICollectionService _collectionService;


        public NoteService(INoteRepository noteRepository, ICollectionService collectionService)
        {
            _noteRepository = noteRepository;
            _collectionService = collectionService;
        }
        public async Task<Note> AddNoteAsync(Note newNote)
        {
            return await _collectionService.HasCollectionAsync(newNote.CollectionId)
                   ? await _noteRepository.AddAsync(newNote)
                   : throw new NotFoundException($"Collection with given Id : {newNote.CollectionId} does not exist!");
        }

        public async Task<int> DeleteNoteAsync(Guid id)
        {
          return await _noteRepository.DeleteAsync(id);
        }

        public async Task<List<Note>> GetAllNotesAync(Guid? collectionId = null, PaginationFilter? filter = null)
        {
            filter = filter ?? new PaginationFilter();

             return collectionId == null 
                ? await _noteRepository.GetAllAsync(filter) 
                : await _noteRepository.GetAllNotesByCollectionIdAsync((Guid)collectionId, filter) ;

        }

        //public async Task<List<Note>> GetAllNotesByFilter(PaginationFilter filter)
        //{
          
        //        return await GetAllNotesByFilter(filter);
        //}

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

            oldNote!.EditNote(
                newNote.CollectionId == Guid.Empty
                ? oldNote.CollectionId
                : (await _collectionService.HasCollectionAsync(newNote.CollectionId)
                            ? newNote.CollectionId
                            : throw new NotFoundException($"Collection with given Id:{newNote.CollectionId} does not exist!")),
                newNote.Title ?? oldNote.Title,
                newNote.Description ?? oldNote.Description!,
                newNote.UpdatedDate);

            await _noteRepository.UpdateAsync(oldNote);
            }
           
        }
    }

