using System.Collections.Generic;
using System.ComponentModel;
using ExportManagementAPI.Domain.Entities.Bases;

namespace ExportManagementAPI.Domain.Entities.API
{
    public class ResponseUnprocessableEntity : ResponseBase
    {
        public List<ErrorEntity> Errors { get; set; }
    }
}