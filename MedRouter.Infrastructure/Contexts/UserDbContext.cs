using MedRouter.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MedRouter.Infrastructure.Contexts;

public class UserDbContext : IdentityDbContext<ApplicationUser>
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

    }
    
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.DateAdded = DateTime.UtcNow;
                    /*entry.Entity.CreatedBy = _authenticatedUser.UserId;*/
                    break;
                case EntityState.Modified:
                    entry.Entity.DateUpdated = DateTime.UtcNow;
                    /*entry.Entity.LastModifiedBy = _authenticatedUser.UserId;*/
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<ApplicationUser>(entity =>
        {
            
            entity.ToTable(name: "ApplicationUser");
        });
        this.SeedRoles(builder);
    }

    private void SeedRoles(ModelBuilder builder)
    {
        
        builder.Entity<IdentityRole>().HasData(
                new IdentityRole() {Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "ADMIN"},
                new IdentityRole() {Name = "Basic", ConcurrencyStamp = "2", NormalizedName = "BASIC"}
            );
    }
}