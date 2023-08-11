using Microsoft.IdentityModel.Tokens;
using System.Net.Mime;
using System.Net;

namespace NoteAPI.ExceptionHandling;

    public class  GlobalExceptionHandlingMiddleWare
    {
     private readonly  RequestDelegate next;
     private readonly ILogger<GlobalExceptionHandlingMiddleWare> logger;

    public GlobalExceptionHandlingMiddleWare(RequestDelegate next, ILogger<GlobalExceptionHandlingMiddleWare> logger)
    {
        this.next = next;
        this.logger = logger;
    }
    public async Task InvokeAsync(HttpContext context) 
    {
        try
        {
            await next(context);




        }
        catch (Exception ex) 
        {
            logger.LogError(ex.Message);
            await HandleExceptionAsync(context, ex);
        
        }
    
        async Task HandleExceptionAsync(HttpContext context, Exception message ) 
        {
            context.Response.ContentType = MediaTypeNames.Application.Json;
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;



            var customResponse = new CustomExceptionResponse("Something bad happened please try again", context.Response.StatusCode, null);

            await context.Response.WriteAsJsonAsync(customResponse);




        }


    }

}

