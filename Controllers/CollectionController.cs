using AutoMapper;
using Azure.Core;
using CollectionAPI.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
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
    private readonly IMapper mapper;
    public CollectionController(ICollectionService collectionService, IMapper mapper)
    {
        this.collectionService = collectionService;
        this.mapper = mapper;
    }

    [HttpGet(ApiRoutes.Collections.GetAll)]
    public async Task<IActionResult> GetAllCollectionsAync()
    {

        var collection = await collectionService.GetAllCollectionsAync();

        return Ok(mapper.Map<List<GetCollectionResponse>>(collection));

    }


    [HttpGet(ApiRoutes.Collections.Get)]
    public async Task<IActionResult> GetCollectionById([FromRoute] Guid id)
    {
        var collection = await collectionService.GetCollectionByIdAsync(id);
        return collection != null
               ? Ok(mapper.Map<GetCollectionResponse>(collection))
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

        var collectionToUpdate = mapper.Map<Collection>(request);

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

        var collection = mapper.Map<Collection>(newCollection);

        var addedCollection = await collectionService.AddCollectionAsync(collection);

        //TODO mapp domain to response
        return Ok(addedCollection);

    }

}