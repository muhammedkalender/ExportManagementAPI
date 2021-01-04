using System.ComponentModel;

namespace ExportManagementAPI.Domain.Entities.Bases
{
    public class ResponseBase
    {
        [DefaultValue(false)]
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}