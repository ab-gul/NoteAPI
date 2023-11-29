using System.ComponentModel;

namespace NoteAPI.Pagination
{
    public class Response<T>
    {
        public Response()
        {
            
        }
        public Response(T data) 
        {
            Succeeded = true;
            Message = null;
            Errors = null;
            Data = data;
        }

        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public string Errors { get; set; }
        public string Message { get; set; }








    }
}
