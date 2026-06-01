
namespace deger_yolculari.Application.DTOs.Events
{
    public class EventDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? Location { get; set; }
        public DateTime EventDate { get; set; }
        public string? ImageUrl { get; set; }
        public List<string> ImageUrls { get; set; } = new();
        public bool IsPublished { get; set; }
        public DateTime CreatedAt { get; set; }
        public string AdminName { get; set; } = string.Empty;
    }

    public class CreateEventDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? Location { get; set; }
        public DateTime EventDate { get; set; }
        public List<string> ImageUrls { get; set; } = new();
        public bool IsPublished { get; set; } = false;
    }

    public class UpdateEventDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? Location { get; set; }
        public DateTime EventDate { get; set; }
        public List<string> ImageUrls { get; set; } = new();
        public bool IsPublished { get; set; }
    }
}
