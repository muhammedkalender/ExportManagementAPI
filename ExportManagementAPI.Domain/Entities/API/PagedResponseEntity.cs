using System.Collections.Generic;

namespace ExportManagementAPI.Domain.Entities.API
{
    public class PagedResponseEntity<T>
    {
        public int TotalRecord { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPage { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public List<ErrorEntity> Errors { get; set; }

        public PagedResponseEntity(T data, int totalRecord, int pageNumber, int pageSize, int totalPage)
        {
            TotalRecord = totalRecord;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalPage = totalPage;
            Data = data;
            Message = null;
            IsSuccess = true;
            Errors = null;
        }
    }
}