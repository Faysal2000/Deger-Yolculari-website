using deger_yolculari.Domain.Common;

namespace deger_yolculari.Domain.Entities;

public class DonationCampaign : BaseEntity
{
    public Guid AdminId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal GoalAmount { get; set; }
    public decimal CollectedAmount { get; set; } = 0;
    public string? ImageUrl { get; set; }
    public bool IsOpen { get; set; } = true;
    public string Currency { get; set; } = "TRY";
    public DateTime StartDate { get; set; } = DateTime.UtcNow;
    public DateTime? EndDate { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    public User Admin { get; set; } = null!;
    public ICollection<Donation> Donations { get; set; } = new List<Donation>();

    public decimal ProgressPercentage =>
        GoalAmount > 0 ? Math.Min(100, (CollectedAmount / GoalAmount) * 100) : 0;
}