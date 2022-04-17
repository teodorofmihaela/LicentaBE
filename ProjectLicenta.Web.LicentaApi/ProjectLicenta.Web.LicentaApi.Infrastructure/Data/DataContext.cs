using Microsoft.EntityFrameworkCore;
using ProjectLicenta.Web.LicentaApi.Core.Models;

namespace ProjectLicenta.Web.LicentaApi.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Utilizatori> Utilizatori { get; set; }
        public DbSet<Anunturi> Anunturi { get; set; }
        public DbSet<Servicii> Servicii { get; set; }
        public DbSet<Cautari> Cautari { get; set; }
        public DbSet<FeedBacks> FeedBacks { get; set; }
        public DbSet<UtilizatoriFavoriti> UtilizatoriFavoriti { get; set; }
        public DbSet<AnunturiPrestate> AnunturiPrestate { get; set; }
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SetModelRelations(modelBuilder);
            SetIndexes(modelBuilder);
        }

        private void SetModelRelations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anunturi>()
                .HasOne(a => a.Id)
                .WithMany(a => a.IdUtilizator)
                .HasForeignKey(a => a.IdUtilizator);
        }

        private void SetIndexes(ModelBuilder modelBuilder)
        {
        }

        

    }
}