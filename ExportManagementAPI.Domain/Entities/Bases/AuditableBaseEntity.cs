using System;

namespace ExportManagementAPI.Domain.Entities.Bases
{
    public class AuditableBaseEntity
    {
        public Guid InsertUser { get; set; }
        public DateTime InsertDate { get; set; }
        public Guid UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}