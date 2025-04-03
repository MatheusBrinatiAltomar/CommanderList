using Microsoft.EntityFrameworkCore;
using MagicCardInfo.Domain.Models;

namespace MagicCardInfo.Infrastructure.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) { }

        public DbSet<Card> Cards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Card Entity
            modelBuilder.Entity<Card>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Name).IsRequired().HasMaxLength(255);
                entity.Property(c => c.OracleText).IsRequired().HasMaxLength(1000);
                entity.Property(c => c.ManaCost).IsRequired().HasMaxLength(50);
                entity.Property(c => c.TypeLine).IsRequired().HasMaxLength(255);
                entity.Property(c => c.ScryfallURI).IsRequired().HasMaxLength(500);

                entity.OwnsOne(c => c.ImageURIs, image =>
                {
                    image.Property(i => i.Normal).HasColumnName("ImageURI_Normal").HasMaxLength(500);
                });
            });
        }
    }
}