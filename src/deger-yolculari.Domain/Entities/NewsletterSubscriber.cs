
using deger_yolculari.Domain.Common;



namespace deger_yolculari.Domain.Entities
{
    public class NewsletterSubscriber: BaseEntity
    {

        public string Email { get; set; } = string.Empty;

        public string? FullName { get; set; }

        public bool IsActive { get; set; } = true;

        public string ConfirmationToken { get; set; } = Guid.NewGuid().ToString("N");

        public bool IsConfirmed { get; set; } = false;

        public DateTime SubscribedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UnsubscribedAt { get; set; }

    }
}
