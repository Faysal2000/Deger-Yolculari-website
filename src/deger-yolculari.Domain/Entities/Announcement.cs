using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using deger_yolculari.Domain.Common;

namespace deger_yolculari.Domain.Entities
{
    public class Announcement : BaseEntity
    {

        public Guid AdminId { get; set; } 

        public string Title { get; set; } = string.Empty;       

        public string Content { get; set; } = string.Empty;

        public bool IsActive { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set;}

        public User Admin { get; set; } = null!; // Navigation property to the User entity representing the admin who created the announcement

    }
}
