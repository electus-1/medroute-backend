using MedRouter.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedRouter.Infrastructure.Contexts;

public class ApplicationDbContext : DbContext
{
    
    public virtual DbSet<Hospital> Hospitals { get; set; }
    public virtual DbSet<Hotel> Hotels { get; set; }
    public virtual DbSet<Landmark> Landmarks { get; set; }
    public virtual DbSet<Location> Locations { get; set; }
    public virtual DbSet<Route> Routes { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
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
        builder.Entity<Route>(entity =>
        {
            entity.HasOne(t => t.Hospital).WithMany().HasForeignKey(b => b.HospitalId).OnDelete(DeleteBehavior.SetNull).HasConstraintName("FK_Route_Hospital");
            entity.HasOne(t => t.Hotel).WithMany().HasForeignKey(b => b.HotelId).OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Route_Hotel");
            entity.HasOne(t => t.ApplicationUser).WithMany().HasForeignKey(b => b.Mail)
                .OnDelete(DeleteBehavior.SetNull);
        });
        builder.Entity<Landmark>(entity =>
        {
            entity.HasOne(t => t.Location).WithMany().HasForeignKey(b => b.LocationId).OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Landmark_Location");
        });
        builder.Entity<Hotel>(entity =>
        {
            entity.HasOne(t => t.Location).WithMany().HasForeignKey(b => b.LocationId).OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Hotal_Location");
        });
        builder.Entity<Hospital>(entity =>
        {
            entity.HasOne(t => t.Location).WithMany().HasForeignKey(b => b.LocationId).OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Hospital_Location");
        });
        
        
    }
}