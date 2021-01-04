using System.Collections.Generic;

namespace ExportManagementAPI.Domain.Entities.API
{
    public class PagedResponseEntity<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public List<ErrorEntity> Errors { get; set; }

        public PagedResponseEntity(T data, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Data = data;
            Message = null;
            IsSuccess = true;
            Errors = null;
        }
    }
}