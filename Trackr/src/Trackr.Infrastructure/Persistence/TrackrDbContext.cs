using Microsoft.EntityFrameworkCore;
using Trackr.Domain.Entities;
using Trackr.Infrastructure.Persistence.Configurations;

namespace Trackr.Infrastructure.Persistence;

public class TrackrDbContext: DbContext
{
    public TrackrDbContext(DbContextOptions<TrackrDbContext> options)
        : base(options) { }

    public DbSet<JobApplication> JobApplications => Set<JobApplication>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new JobApplicationConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}