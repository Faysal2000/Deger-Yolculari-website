using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using deger_yolculari.Domain.Common;



namespace deger_yolculari.Domain.Entities
{
    public class AuditLog : BaseEntity
    {

        public Guid AdminId { get; set; }

        public string Action { get; set; } = string.Empty;

        public string? EntityType { get; set; } = string.Empty;

        public string? EntityId { get; set; } = string.Empty;
        public string? Details { get; set; }
        public string? IpAddress { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime CreatedAt { get; set; }

        public User Admin { get; set; } = null!;



    }
}