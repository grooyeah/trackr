using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trackr.Domain.Entities;

namespace Trackr.Infrastructure.Persistence.Configurations;

public class JobApplicationConfiguration: IEntityTypeConfiguration<JobApplication>
{
    public void Configure(EntityTypeBuilder<JobApplication> builder)
    {
        builder.ToTable("job_applications");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id");

        builder.Property(x => x.CompanyName)
            .HasColumnName("company_name")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.RoleTitle)
            .HasColumnName("role_title")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.JobUrl)
            .HasColumnName("job_url")
            .HasMaxLength(1000);

        builder.Property(x => x.Status)
            .HasColumnName("status")
            .HasConversion<string>()
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.AppliedAt)
            .HasColumnName("applied_at");

        builder.Property(x => x.Notes)
            .HasColumnName("notes")
            .HasMaxLength(5000);

        builder.Property(x => x.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(x => x.UpdatedAt)
            .HasColumnName("updated_at")
            .IsRequired();

        builder.Property(x => x.DeletedAt)
            .HasColumnName("deleted_at");

        builder.HasIndex(x => x.Status)
            .HasDatabaseName("ix_job_applications_status");

        builder.HasIndex(x => x.CreatedAt)
            .HasDatabaseName("ix_job_applications_created_at");

        builder.HasQueryFilter(x => x.DeletedAt == null);
    }
}