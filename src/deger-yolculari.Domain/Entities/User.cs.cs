using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using deger_yolculari.Domain.Common;

namespace deger_yolculari.Domain.Entities
{
    public class User: BaseEntity
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool EmailConfirmed { get; set; } = false;
        public string? PhoneNumber { get; set; }
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = "User";
        public string SecurityStamp { get; set; } = Guid.NewGuid().ToString();
        public bool IsActive { get; set; } = true;
        public bool LockoutEnabled { get; set; } = false;
        public DateTimeOffset? LockoutEnd { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiry { get; set; }






        // Navigation Properties
        public ICollection<News> News { get; set; } = new List<News>();
        public ICollection<Event> Events { get; set; } = new List<Event>();
        public ICollection<Announcement> Announcements { get; set; } = new List<Announcement>();
        public ICollection<Article> Articles { get; set; } = new List<Article>();
        public ICollection<FileDocument> Files { get; set; } = new List<FileDocument>();
        public ICollection<Gallery> Gallery { get; set; } = new List<Gallery>();
        public ICollection<DonationCampaign> DonationCampaigns { get; set; } = new List<DonationCampaign>();
        public ICollection<Donation> Donations { get; set; } = new List<Donation>();
        public ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();





    }
}
