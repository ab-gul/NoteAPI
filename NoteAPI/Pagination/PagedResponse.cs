namespace NoteAPI.Pagination
{
    public class PagedResponse<T>: Response<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public Uri FirstPage { get; set; }
        public Uri LastPage { get; set; } 
        public int TotalCount { get; set; }


        public PagedResponse(T data, int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.Data = data;
            this.Message = String.Empty;
            this.Errors = String.Empty;
            this.Succeeded = true;


            
        }
    }
}
