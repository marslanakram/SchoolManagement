using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Data.Entities
{
    public abstract class BaseEntity
    {

        public int Id { get; set; }

        // Soft delete fields
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
        public string? DeletedBy { get; set; }

        // Creation audit fields
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string CreatedBy { get; set; } = "system";

        // Modification audit fields
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }

        // Concurrency control
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
