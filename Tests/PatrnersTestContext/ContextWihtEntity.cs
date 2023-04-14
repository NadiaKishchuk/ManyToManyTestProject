using Microsoft.EntityFrameworkCore;
using Tests.PatrnersTestContext.Models;

namespace Tests.PatrnersTestContext
{
    //context like in the Streetcode project
    internal class ContextWihtEntity: DbContext
    {
        public DbSet<Streetcode> Streetcodes { get; set; }
        public DbSet<Partner> Partners { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Streetcode>()
                .HasMany(s => s.Partners)
            .WithMany(p => p.Streetcodes)
            .UsingEntity(j => j.ToTable("streetcode_partners"));
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-I7Q35NQ\\SQLEXPRESS;Database=ContextWihtEntity;User Id=sa;Password=Admin@1234;MultipleActiveResultSets=true;TrustServerCertificate=true;");
        }
    }

    internal class ContextWihtEntityExplicit : DbContext
    {
        public DbSet<Streetcode> Streetcodes { get; set; }
        public DbSet<Partner> Partners { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Streetcode>()
                .HasMany(s => s.Partners)
            .WithMany(p => p.Streetcodes)
            .UsingEntity<StreetcodePartner>(
                sp=>sp.HasOne(x =>x.Partner).WithMany().HasForeignKey(x =>x.PartnerId),
                sp=>sp.HasOne(x =>x.Streetcode).WithMany().HasForeignKey(x =>x.StreetcodeId)
                );
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-I7Q35NQ\\SQLEXPRESS;Database=ContextWihtExplicitEntity;User Id=sa;Password=Admin@1234;MultipleActiveResultSets=true;TrustServerCertificate=true;");
        }
    }

    internal class ContextWihtoutEntity : DbContext
    {
        public DbSet<Streetcode> Streetcodes { get; set; }
        public DbSet<Partner> Partners { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Streetcode>()
                .HasMany(s => s.Partners)
            .WithMany(p => p.Streetcodes);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-I7Q35NQ\\SQLEXPRESS;Database=ContextWihtoutitEntity;User Id=sa;Password=Admin@1234;MultipleActiveResultSets=true;TrustServerCertificate=true;");
        }
    }
}
