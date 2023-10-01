namespace NoteAPI.Mapping
{
    public class PageResponse<T>
    {
        public PageResponse() { }

        public PageResponse(T data)
        {
            Data = data;
        }

        public T Data { get; set; }
        public int? PageSize { get; set; } = null;
        public int? PageNumber { get; set; }= null;

        public string PreviousPage { get; set; } = string.Empty;
        public string NextPage { get; set; } = string.Empty;
    }
}
