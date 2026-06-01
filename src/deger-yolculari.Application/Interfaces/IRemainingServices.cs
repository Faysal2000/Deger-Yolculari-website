using deger_yolculari.Application.DTOs.Admin;
using deger_yolculari.Application.DTOs.Announcements;
using deger_yolculari.Application.DTOs.Articles;
using deger_yolculari.Application.DTOs.Common;
using deger_yolculari.Application.DTOs.Donations;
using deger_yolculari.Application.DTOs.Newsletter;
using deger_yolculari.Application.DTOs.SiteSettings;



namespace deger_yolculari.Application.Interfaces
{
    public interface IAnnouncementService
    {
        Task<PagedResult<AnnouncementDto>> GetAllAsync(PaginationParams paginationParams, bool activeOnly = true);
        Task<ApiResponse<AnnouncementDto>> GetByIdAsync(Guid id);
        Task<ApiResponse<AnnouncementDto>> CreateAsync(Guid adminId, CreateAnnouncementDto dto);
        Task<ApiResponse<AnnouncementDto>> UpdateAsync(Guid adminId, Guid id, UpdateAnnouncementDto dto);
        Task<ApiResponse<bool>> DeleteAsync(Guid adminId, Guid id);
    }

    public interface IArticleService
    {
        Task<PagedResult<ArticleDto>> GetAllAsync(PaginationParams paginationParams, bool publishedOnly = true);
        Task<ApiResponse<ArticleDto>> GetByIdAsync(Guid id);
        Task<ApiResponse<ArticleDto>> CreateAsync(Guid adminId, CreateArticleDto dto);
        Task<ApiResponse<ArticleDto>> UpdateAsync(Guid adminId, Guid id, UpdateArticleDto dto);
        Task<ApiResponse<bool>> DeleteAsync(Guid adminId, Guid id);
    }

    public interface IDonationService
    {
        Task<PagedResult<DonationCampaignDto>> GetCampaignsAsync(PaginationParams paginationParams, bool openOnly = false);
        Task<ApiResponse<DonationCampaignDto>> GetCampaignByIdAsync(Guid id);
        Task<ApiResponse<DonationCampaignDto>> CreateCampaignAsync(Guid adminId, CreateCampaignDto dto);
        Task<ApiResponse<DonationCampaignDto>> UpdateCampaignAsync(Guid adminId, Guid id, UpdateCampaignDto dto);

        Task<ApiResponse<bool>> ToggleCampaignAsync(Guid adminId, Guid id);
        Task<ApiResponse<bool>> DeleteCampaignAsync(Guid adminId, Guid id);

        Task<ApiResponse<DonationDto>> InitiateDonationAsync(Guid? userId, InitiateDonationDto dto);
        Task<ApiResponse<ThreeDSInitiateResponseDto>> InitiateThreeDSAsync(Guid? userId, InitiateDonationDto dto);
        Task<string> HandleCallbackAsync(IyzicoCallbackDto dto);
        Task<PagedResult<DonationDto>> GetUserDonationsAsync(Guid userId, PaginationParams paginationParams);
        Task<ApiResponse<byte[]>> GenerateCertificateAsync(Guid donationId, Guid? userId);
    }

    public interface INewsletterService
    {
        Task<ApiResponse<bool>> SubscribeAsync(SubscribeDto dto);
        Task<ApiResponse<bool>> ConfirmSubscriptionAsync(string token);
        Task<ApiResponse<bool>> UnsubscribeAsync(string token);
        Task<PagedResult<NewsletterSubscriberDto>> GetSubscribersAsync(PaginationParams paginationParams);
    }

    public interface IAdminService
    {
        Task<ApiResponse<DashboardStatsDto>> GetDashboardStatsAsync();
        Task<byte[]> ExportDonationsToExcelAsync(DateTime? from, DateTime? to);
        Task<PagedResult<AuditLogDto>> GetAuditLogsAsync(PaginationParams paginationParams);
    }


    public interface IAuditService
    {
        Task LogAsync(Guid adminId, string action, string entityType, string entityId, string? details = null, string? ipAddress = null);
    }



    public interface ISiteSettingsService
    {
        Task<ApiResponse<SiteSettingsDto>> GetSettingsAsync();
        Task<ApiResponse<SiteSettingsDto>> UpdateSettingsAsync(Guid adminId, UpdateSiteSettingsDto dto);
    }

    public interface IFileService
    {
        Task<PagedResult<deger_yolculari.Application.DTOs.Files.FileDocumentDto>> GetFilesAsync(PaginationParams p);
        Task<ApiResponse<deger_yolculari.Application.DTOs.Files.FileDocumentDto>> UploadFileAsync(Guid adminId, Microsoft.AspNetCore.Http.IFormFile file, string baseUrl);
        Task<ApiResponse<string>> UploadImageAsync(Guid adminId, Microsoft.AspNetCore.Http.IFormFile file, string baseUrl);
        Task<ApiResponse<bool>> DeleteFileAsync(Guid adminId, Guid id);
    }
}