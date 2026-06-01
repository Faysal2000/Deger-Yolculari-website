namespace deger_yolculari.Application.DTOs.Stats;

public class PublicStatsDto
{
    public int TotalDonors { get; set; }
    public decimal TotalDonationsAmount { get; set; }
    public int ActiveCampaigns { get; set; }
    public int NewsletterSubscribers { get; set; }
    public string Beneficiaries { get; set; } = "5.000+";
}
