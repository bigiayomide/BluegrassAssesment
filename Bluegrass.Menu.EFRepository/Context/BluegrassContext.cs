
using Bluegrass.Menu.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bluegrass.Menu.EFRepository.Context
{
  public class BluegrassContext : DbContext
  {
    public BluegrassContext(DbContextOptions<BluegrassContext> options)
      : base(options) { }

    public virtual DbSet<Models.Menu> Menu { get; set; }
    public virtual DbSet<User> User { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.Entity<Models.Menu>()
                    .HasOne(c => c.ParentMenu)
                    .WithMany()
                    .HasForeignKey(c => c.ParentId);

      modelBuilder.Entity<User>()
                    .HasMany(c => c.Menu);
    }
  }
}
