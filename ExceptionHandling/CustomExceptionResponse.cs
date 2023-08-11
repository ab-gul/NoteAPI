namespace NoteAPI.ExceptionHandling;

    public record CustomExceptionResponse(string Message, int StatusCode, string ? Details);
  

