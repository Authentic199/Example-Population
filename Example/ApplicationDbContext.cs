using Example.Entities;
using Humanizer;
using Microsoft.EntityFrameworkCore;

namespace Example;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = default!;

    public DbSet<Role> Roles { get; set; } = default!;

    public DbSet<Permission> Permissions { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(
            entityBuilder =>
            {
                entityBuilder.ToTable(nameof(User).Underscore());
                entityBuilder.HasKey(x => x.Id);

                entityBuilder.HasOne(x => x.Role)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.RoleId);
            });

        modelBuilder.Entity<Role>(entityBuilder =>
        {
            entityBuilder.ToTable(nameof(Role).Underscore());
            entityBuilder.HasKey(x => x.Id);
        });

        modelBuilder.Entity<Permission>(entityBuilder =>
        {
            entityBuilder.ToTable(nameof(Permission).Underscore());
            entityBuilder.HasKey(x => x.Code);

            entityBuilder.HasOne(x => x.Role)
            .WithMany(x => x.Permissions)
            .HasForeignKey(x => x.RoleId);
        });
    }
}
