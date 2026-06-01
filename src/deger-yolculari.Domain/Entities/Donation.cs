
using deger_yolculari.Domain.Common;

namespace deger_yolculari.Domain.Entities
{
    public class Donation : BaseEntity
    {
        public Guid? UserId { get; set; }

        public Guid CampaignId { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; } = "TRY";

        public string? TransactionId { get; set; }

        public string Status { get; set; } = "Pending";

        public string PaymentMethod { get; set; } = string.Empty;

        public string? Notes { get; set; } = string.Empty;

        public string? DonorName { get; set; }

        public string? DonorEmail { get; set; }

        public string? IyzicoPaymentId { get; set; }

        public string? IyzicoConversationId { get; set; }

        public DateTime DonatedAt { get; set; } = DateTime.UtcNow;

        public User? User { get; set; }

        public DonationCampaign Campaign { get; set; } = null!;
    }
}