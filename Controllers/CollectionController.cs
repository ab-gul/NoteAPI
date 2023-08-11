using CollectionAPI.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using NoteAPI.Domain;
using NoteAPI.DTOs.NoteResponses;
using System.ComponentModel;
using System.Reflection;
using static NoteAPI.DTOs.NoteResponses.CollectionResponse;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace NoteAPI.Controllers;


[Route("api/[controller]")]
[ApiController]
public class CollectionController : ControllerBase
{
    private readonly ICollectionService collectionService;

    public CollectionController(ICollectionService collectionService)
    {
        this.collectionService = collectionService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCollectionsAync()
    {

        List<GetCollectionResponse> response = new();
        var collect = await collectionService.GetAllCollectionsAync();

        foreach (var i in collect)
        {
            response.Add(new GetCollectionResponse
            {

                Id = i.ID,
                Title = i.Title,
                Description = i.Description,
                CreatedDate = i.CreatedDate

            });
        }

        return collect.Any() ? Ok(collect) : NoContent();
    }

    public async Task<IActionResult> GetCollectionById([FromRoute]Guid id) 
    {
       var collection = await collectionService.GetCollectionByIdAsync(id); 
    
      return collection != null ? Ok(new GetCollectionResponse {
       Id = id,
       Title = collection.Title,
       Description = collection.Description,
       CreatedDate = collection.CreatedDate

      }) : NoContent();
    
    }

    public async Task<IActionResult> DeleteCollectionAsync([FromRoute]Guid id) 
    {
    
      var collection = await collectionService.GetCollectionByIdAsync(id);

        if (collection != null) { NotFound(); }

        await collectionService.DeleteCollectionAsync(id);
        return NotFound();
    }

    public async Task<IActionResult> UpdateCollectionAsync([FromRoute]Guid id, [FromBody]string text) 
    {
     var collection = await collectionService.GetCollectionByIdAsync(id);
        if (collection != null) { new GetCollectionResponse {
         Id = id,
         Title = collection.Title, 
         Description = collection.Description,
         CreatedDate = collection.CreatedDate
        
        }; }
        return Ok(collection);
    }

















}  
            


            






 

