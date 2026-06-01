namespace deger_yolculari.Application.DTOs.Newsletter;

public class SubscribeDto
{
    public string Email { get; set; } = string.Empty;
    public string? FullName { get; set; }
}

public class NewsletterSubscriberDto
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string? FullName { get; set; }
    public bool IsConfirmed { get; set; }
    public bool IsActive { get; set; }
    public DateTime SubscribedAt { get; set; }
}