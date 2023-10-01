namespace NoteAPI.Mapping
{
    public class ResponseAPI<T>
    {
        public ResponseAPI() { }
        
        public ResponseAPI(T response) 
        {
         Data = response;
        }
        public T Data { get; set; }
    }
}
