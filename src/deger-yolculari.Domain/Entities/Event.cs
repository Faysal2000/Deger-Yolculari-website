using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using deger_yolculari.Domain.Common;

namespace deger_yolculari.Domain.Entities
{
    public class Event: BaseEntity
    {
        public Guid AdminId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }

        public string? Location { get; set; } = string.Empty;

        public DateTime EventDate { get; set; }
        public string? ImageUrl { get; set; }

        public bool IsPublished { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
        public User Admin { get; set; } = null!;


        public ICollection<Gallery> Gallery { get; set; } = new List<Gallery>();


    }


}
