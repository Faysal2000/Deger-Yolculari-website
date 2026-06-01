using deger_yolculari.Domain.Common;


namespace deger_yolculari.Domain.Entities
{
    public class News : BaseEntity
    {
        public Guid AdminId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }

        public bool IsPublished { get; set; } = false;
        public DateTime? PublishedAt { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }


        public User Admin { get; set; } = null!;

    }
}
