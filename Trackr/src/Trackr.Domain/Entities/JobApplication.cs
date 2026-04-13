using Trackr.Domain.Enums;

namespace Trackr.Domain.Entities;

public class JobApplication
{
    public Guid Id { get; private set; }
    public string CompanyName { get; private set; } = default!;
    public string RoleTitle { get; private set; } = default!;
    public string? JobUrl { get; private set; }
    public ApplicationStatus Status { get; private set; }
    public DateTimeOffset? AppliedAt { get; private set; }
    public string? Notes { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }
    public DateTimeOffset UpdatedAt { get; private set; }
    public DateTimeOffset? DeletedAt { get; private set; }

    private JobApplication() { }

    public static JobApplication Create(
        string companyName,
        string roleTitle,
        string? jobUrl,
        string? notes)
    {
        return new JobApplication
        {
            Id = Guid.NewGuid(),
            CompanyName = companyName,
            RoleTitle = roleTitle,
            JobUrl = jobUrl,
            Notes = notes,
            Status = ApplicationStatus.Saved,
            CreatedAt = DateTimeOffset.UtcNow,
            UpdatedAt = DateTimeOffset.UtcNow
        };
    }

    public void UpdateStatus(ApplicationStatus newStatus)
    {
        Status = newStatus;
        if (newStatus == ApplicationStatus.Applied)
            AppliedAt = DateTimeOffset.UtcNow;
        UpdatedAt = DateTimeOffset.UtcNow;
    }

    public void Delete()
    {
        DeletedAt = DateTimeOffset.UtcNow;
        UpdatedAt = DateTimeOffset.UtcNow;
    }
}