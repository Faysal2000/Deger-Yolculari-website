namespace deger_yolculari.Application.DTOs.Admin;

public class DashboardStatsDto
{
    public int TotalUsers { get; set; }
    public int TotalNews { get; set; }
    public int TotalEvents { get; set; }
    public int ActiveCampaigns { get; set; }
    public decimal TotalDonationsAmount { get; set; }
    public int TotalDonors { get; set; }
    public int NewsletterSubscribers { get; set; }
    public List<MonthlyDonationDto> MonthlyDonations { get; set; } = new();
    public List<CampaignSummaryDto> TopCampaigns { get; set; } = new();
}

public class MonthlyDonationDto
{
    public int Year { get; set; }
    public int Month { get; set; }
    public decimal TotalAmount { get; set; }
    public int DonationCount { get; set; }
}

public class CampaignSummaryDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public decimal GoalAmount { get; set; }
    public decimal CollectedAmount { get; set; }
    public decimal ProgressPercentage { get; set; }
}

public class AuditLogDto
{
    public Guid Id { get; set; }
    public string AdminName { get; set; } = string.Empty;
    public string Action { get; set; } = string.Empty;
    public string EntityType { get; set; } = string.Empty;
    public string EntityId { get; set; } = string.Empty;
    public string? Details { get; set; }
    public string? IpAddress { get; set; }
    public DateTime CreatedAt { get; set; }
}