using CManager.Models;
using Dropbox.Api.TeamLog;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CManager.Models;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public DbSet<Collection> Collections { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Comment> Comments { get; set; }
    
    public DbSet<Like> Likes { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        var adminRole = new IdentityRole("admin");
        adminRole.NormalizedName = "ADMIN";
        var userRole = new IdentityRole("user");
        userRole.NormalizedName = "USER";

        modelBuilder.Entity<IdentityRole>()
            .HasData(new IdentityRole[] {adminRole, userRole});

        modelBuilder.Entity<Collection>(b =>
        {
            b.ToTable("Collections");
            b.HasKey(p => p.Id);
            b.Property(p => p.AuthorId).HasColumnName("AuthorId").IsRequired();
            b.Property(p => p.Title).HasColumnName("Title").IsRequired();
            b.Property(p => p.Description).HasColumnName("Description").IsRequired();
            b.Property(p => p.Theme).HasColumnName("Theme").IsRequired();
            b.Property(p => p.LastEditDate).HasColumnName("LastEditDate").IsRequired();
            b.Property(p => p.AddDates).HasColumnName("AddDates");
            b.Property(p => p.AddBrands).HasColumnName("AddBrands");
            b.Property(p => p.AddComments).HasColumnName("AddComments");
        });

        modelBuilder.Entity<Item>(b =>
        {
            b.ToTable("Items");
            b.HasKey(p => p.Id);
            b.Property(p => p.CollectionId).HasColumnName("CollectionId").IsRequired();
            b.Property(p => p.Title).HasColumnName("Title").IsRequired();
            b.Property(p => p.Description).HasColumnName("Description").IsRequired();
            b.Property(p => p.LastEditDate).HasColumnName("LastEditDate").IsRequired();
            b.Property(p => p.Date).HasColumnName("Date");
            b.Property(p => p.Brand).HasColumnName("Brand");
        });

        base.OnModelCreating(modelBuilder);
        
    }
}