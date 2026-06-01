using deger_yolculari.Domain.Entities;


namespace deger_yolculari.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        IRepository<User> Users { get; } 
        IRepository<News> News { get; } 
        IRepository<Event> Events { get; }
        IRepository<Announcement> Announcements { get; }
        IRepository<Article> Articles { get; }
        IRepository<FileDocument> Files { get; }
        IRepository<Gallery> Gallery { get; }
        IRepository<DonationCampaign> DonationCampaigns { get; }
        IRepository<Donation> Donations { get; }
        IRepository<NewsletterSubscriber> NewsletterSubscribers { get; }
        IRepository<AuditLog> AuditLogs { get; }

        IRepository<SiteSettings> SiteSettings { get; }
        IRepository<PasswordResetCode> PasswordResetCodes { get; }


        Task<int> SaveChangesAsync(); 
        Task BeginTransactionAsync(); 
        Task CommitTransactionAsync(); 
        Task RollbackTransactionAsync(); 


    }
}
