using deger_yolculari.Domain.Common;

namespace deger_yolculari.Domain.Entities;

public class PasswordResetCode : BaseEntity
{
    public Guid UserId { get; set; }
    public string CodeHash { get; set; } = string.Empty;
    public DateTime ExpiresAt { get; set; }
    public int AttemptCount { get; set; } = 0;
    public DateTime? LockedUntil { get; set; }
    public string? ResetToken { get; set; }
    public DateTime? ResetTokenExpiresAt { get; set; }
    public bool IsUsed { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public User User { get; set; } = null!;
}
