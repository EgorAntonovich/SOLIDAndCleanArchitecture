using HR.LeaveManagementSystem.Domain;
using HR.LeaveManagementSystem.Domain.Common;
using HR.LeaveManagementSystem.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagementSystem.Persistence.DatabaseContext;

public class HrDatabaseContext : DbContext
{
    public HrDatabaseContext(DbContextOptions<HrDatabaseContext> options) : base(options)
    {
        
    }
    
    public DbSet<LeaveType> LeaveTypes { get; set; }
    public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
    public DbSet<LeaveRequest> LeaveRequests { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(HrDatabaseContext).Assembly);
        modelBuilder.ApplyConfiguration(new LeaveTypeConfiguration());
        modelBuilder.ApplyConfiguration(new LeaveAllocationConfiguration());
        modelBuilder.ApplyConfiguration(new LeaveRequestConfiguration());
        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in base.ChangeTracker
                     .Entries<BaseEntity>()
                     .Where(q => q.State is EntityState.Added or EntityState.Modified))
        {
            entry.Entity.DateModified = DateTime.Now;
            
            if (entry.State == EntityState.Added)
            {
                entry.Entity.DateCreated = DateTime.Now;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}