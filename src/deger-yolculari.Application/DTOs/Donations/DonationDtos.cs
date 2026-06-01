namespace deger_yolculari.Application.DTOs.Donations;

public class DonationCampaignDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public decimal GoalAmount { get; set; }
    public decimal CollectedAmount { get; set; }
    public decimal ProgressPercentage { get; set; }
    public string Currency { get; set; } = "TRY";
    public bool IsOpen { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public int DonorCount { get; set; }
}

public class CreateCampaignDto
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public decimal GoalAmount { get; set; }
    public string Currency { get; set; } = "TRY";
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}

public class UpdateCampaignDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public decimal GoalAmount { get; set; }
    public bool IsOpen { get; set; }
    public DateTime? EndDate { get; set; }
}

public class DonationDto
{
    public Guid Id { get; set; }
    public string CampaignTitle { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string Currency { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string? PaymentMethod { get; set; }
    public DateTime DonatedAt { get; set; }
    public string DonorName { get; set; } = string.Empty;
}

public class InitiateDonationDto
{
    public Guid CampaignId { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; } = "TRY";
    public string? Notes { get; set; }
    public string DonorName { get; set; } = string.Empty;
    public string DonorEmail { get; set; } = string.Empty;
    public IyzicoCardDto Card { get; set; } = null!;
}

public class IyzicoCardDto
{
    public string CardHolderName { get; set; } = string.Empty;
    public string CardNumber { get; set; } = string.Empty;
    public string ExpireMonth { get; set; } = string.Empty;
    public string ExpireYear { get; set; } = string.Empty;
    public string Cvc { get; set; } = string.Empty;
}

public class DonationCertificateDto
{
    public string DonorName { get; set; } = string.Empty;
    public string CampaignTitle { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string Currency { get; set; } = string.Empty;
    public DateTime DonatedAt { get; set; }
    public string TransactionId { get; set; } = string.Empty;
}

public class ThreeDSInitiateResponseDto
{
    public Guid DonationId { get; set; }
    public string HtmlContent { get; set; } = string.Empty;
}

public class IyzicoCallbackDto
{
    public string? PaymentId { get; set; }
    public string? ConversationId { get; set; }
    public string? ConversationData { get; set; }
    public string? Status { get; set; }
    public string? MdStatus { get; set; }
}