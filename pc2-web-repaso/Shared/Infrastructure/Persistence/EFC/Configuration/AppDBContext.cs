using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using pc2_web_repaso.Sale.Domain.Model.Aggregates;
using pcWeb.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace pc2_web_repaso.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<PurchaseOrder>().HasKey(p => p.Id);
        builder.Entity<PurchaseOrder>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<PurchaseOrder>().Property(p => p.Customer).IsRequired();
        builder.Entity<PurchaseOrder>().Property(p => p.FabricId).IsRequired();
        builder.Entity<PurchaseOrder>().Property(p => p.City).IsRequired();
        builder.Entity<PurchaseOrder>().Property(p => p.ResumeUrl).IsRequired();
        builder.Entity<PurchaseOrder>().Property(p => p.Quantity).IsRequired();
        builder.Entity<PurchaseOrderAudit>().Property(p => p.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP").ValueGeneratedOnAdd();
        
        builder.Entity<PurchaseOrderAudit>().Property(p => p.UpdatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP").ValueGeneratedOnAddOrUpdate();
        
        builder.Entity<PurchaseOrder>().HasIndex(p => new { p.Customer, p.FabricId }).IsUnique();
        
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}