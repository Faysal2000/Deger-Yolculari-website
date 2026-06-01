using deger_yolculari.Domain.Common;

namespace deger_yolculari.Domain.Entities;

public class SiteSettings : BaseEntity
{
    public string HeroBadgeText { get; set; } = "Bilmekten Çok Yaşamak İçin";
    public string HeroTitle { get; set; } = "İyiiğin Yolculuğuna Hoş Geldiniz";
    public string HeroSubtitle { get; set; } = "Toplumun her kesimine ulaşmak ve kalıcı değişimler oluşturmak için çalışıyoruz.";
    public string PrimaryButtonText { get; set; } = "Bağış Yap";
    public string SecondaryButtonText { get; set; } = "Hakkımızda";
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public Guid? UpdatedByAdminId { get; set; }

    public string VisionTitle { get; set; } = "Vizyonumuz";
    public string VisionContent { get; set; } = "Değer Yolcuları olarak vizyonumuz...";
    public string MissionTitle { get; set; } = "Misyonumuz";
    public string MissionContent { get; set; } = "Değer Yolcuları olarak misyonumuz...";
    public string? LogoUrl { get; set; }
    public string Beneficiaries { get; set; } = "5.000+";
    public string CertificateThankYouMessage { get; set; } = "Değerli bağışınız için içtenlikle teşekkür ederiz. Desteğiniz toplumun her kesimine ulaşmamızı sağlamaktadır.";

    // Navigation
    public User? UpdatedByAdmin { get; set; }
}