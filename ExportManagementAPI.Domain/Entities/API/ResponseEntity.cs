using System.Collections.Generic;

namespace ExportManagementAPI.Domain.Entities.API
{
    public class ResponseEntity<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public List<ErrorEntity> Errors { get; set; }

        public ResponseEntity()
        {
        }

        public ResponseEntity(T data, string message = null)
        {
            IsSuccess = true;
            Message = message;
            Data = data;
        }

        public ResponseEntity(string message)
        {
            IsSuccess = false;
            Message = message;
        }
    }
}