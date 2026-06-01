using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using deger_yolculari.Domain.Common;

namespace deger_yolculari.Domain.Entities
{
    public class Gallery : BaseEntity
    {

        public Guid AdminId { get; set; }

        public Guid? EventId { get; set; }

        public string? ImageUrl { get; set; } = string.Empty;

        public string? Caption { get; set; }
    
        public DateTime? UploadedAt { get; set; } = DateTime.UtcNow;


        public User Admin { get; set; } = null!;
        public Event? Event { get; set; }

    }


}
