using Azure.Core;
using CollectionAPI.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NoteAPI.Common;
using NoteAPI.Domain;
using NoteAPI.DTOs.Collections;
using NoteAPI.DTOs.Notes;
using static NoteAPI.Common.ApiRoutes;


namespace NoteAPI.Controllers;


public class CollectionController : ControllerBase
{
    private readonly ICollectionService collectionService;
    public CollectionController(ICollectionService collectionService)
    {
        this.collectionService = collectionService;
    }

    [HttpGet(ApiRoutes.Collections.GetAll)]
    public async Task<IActionResult> GetAllCollectionsAync()
    {

        var collections = await collectionService.GetAllCollectionsAync();

        return Ok(collections.Select(collection => (GetCollectionResponse)collection));

    }


    [HttpGet(ApiRoutes.Collections.Get)]
    public async Task<IActionResult> GetCollectionById([FromRoute] Guid id)
    {
        var collection = await collectionService.GetCollectionByIdAsync(id);
        return collection != null
               ? Ok((GetCollectionResponse)collection)
               : NotFound($"Collection with given id: {id} does not exists!");

    }

    [HttpDelete(ApiRoutes.Collections.Delete)]
    public async Task<IActionResult> DeleteCollectionAsync([FromRoute] Guid id)
    {

        var collection = await collectionService.GetCollectionByIdAsync(id);

        if (collection != null) { NotFound(); }

        await collectionService.DeleteCollectionAsync(id);

        return NotFound();
    }

    [HttpPut(ApiRoutes.Collections.Update)]
    public async Task<IActionResult> UpdateCollectionAsync([FromRoute] Guid id, [FromBody] UpdateCollectionRequest request, [FromServices] IValidator<UpdateCollectionRequest> validator)
    {

        ArgumentException.ThrowIfNullOrEmpty(nameof(validator));
        ValidationResult validationResult = validator!.Validate(request);

        if (!validationResult.IsValid) 
        {
            validationResult.AddToModelState(this.ModelState);

            return ValidationProblem();

        }
        var collection = await collectionService.GetCollectionByIdAsync(id);

        if (collection == null) { return NotFound($"Collection with given Id:{id} does not exist, please try again..."); };

        var collectionToUpdate = (Collection)request;

        await collectionService.UpdateCollectionAsync(collectionToUpdate);

        return NoContent();
    }

    [HttpPost(ApiRoutes.Collections.Add)]
    public async Task<IActionResult> AddCollectionAsync([FromBody] CreateCollectionRequest newCollection, [FromServices] IValidator <CreateCollectionRequest> validator)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(validator));

        ValidationResult validationResult = validator!.Validate(newCollection);

        if (!validationResult.IsValid)
        {
            validationResult.AddToModelState(this.ModelState);

            return ValidationProblem();
        }

        ArgumentException.ThrowIfNullOrEmpty(nameof(validator));

        var collection = (Collection)newCollection;

        var addedCollection = await collectionService.AddCollectionAsync(collection);

        //TODO mapp domain to response
        return Ok((CreateCollectionResponse)addedCollection);

    }

}