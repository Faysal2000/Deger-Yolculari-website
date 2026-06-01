namespace deger_yolculari.Application.DTOs.SiteSettings;

public class SiteSettingsDto
{
    public Guid Id { get; set; }
    public string HeroBadgeText { get; set; } = string.Empty;
    public string HeroTitle { get; set; } = string.Empty;
    public string HeroSubtitle { get; set; } = string.Empty;
    public string PrimaryButtonText { get; set; } = string.Empty;
    public string SecondaryButtonText { get; set; } = string.Empty;
    public DateTime UpdatedAt { get; set; }


    public string VisionTitle { get; set; } = string.Empty;
    public string VisionContent { get; set; } = string.Empty;
    public string MissionTitle { get; set; } = string.Empty;
    public string MissionContent { get; set; } = string.Empty;
    public string? LogoUrl { get; set; }
    public string Beneficiaries { get; set; } = "5.000+";
    public string CertificateThankYouMessage { get; set; } = string.Empty;
}

public class UpdateSiteSettingsDto
{
    public string HeroBadgeText { get; set; } = string.Empty;
    public string HeroTitle { get; set; } = string.Empty;
    public string HeroSubtitle { get; set; } = string.Empty;
    public string PrimaryButtonText { get; set; } = string.Empty;
    public string SecondaryButtonText { get; set; } = string.Empty;

    public string VisionTitle { get; set; } = string.Empty;
    public string VisionContent { get; set; } = string.Empty;
    public string MissionTitle { get; set; } = string.Empty;
    public string MissionContent { get; set; } = string.Empty;
    public string? LogoUrl { get; set; }
    public string Beneficiaries { get; set; } = "5.000+";
    public string CertificateThankYouMessage { get; set; } = string.Empty;
}