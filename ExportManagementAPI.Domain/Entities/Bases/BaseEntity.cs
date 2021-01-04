using System;

namespace ExportManagementAPI.Domain.Entities.Bases
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public bool Active { get; set; }
    }
}