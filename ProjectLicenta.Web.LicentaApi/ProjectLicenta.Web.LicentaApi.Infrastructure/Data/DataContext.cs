using Microsoft.EntityFrameworkCore;
using ProjectLicenta.Web.LicentaApi.Core.Models;

namespace ProjectLicenta.Web.LicentaApi.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Utilizator> Utilizatori { get; set; }
        public DbSet<Anunt> Anunturi { get; set; }
        public DbSet<Serviciu> Servicii { get; set; }
        public DbSet<Cautare> Cautari { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<UtilizatorFavorit> UtilizatoriFavoriti { get; set; }
        public DbSet<AnuntPrestat> AnunturiPrestate { get; set; }
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //UtilizatoriFavoriti are doua chei primare
            /*modelBuilder.Entity<UtilizatoriFavoriti>()
                .HasKey(u => new 
                { 
                    u.Id, 
                    u.IdUtilizatorFavorit 
                });
                */
            
            //SetModelRelations(modelBuilder);
            SetIndexes(modelBuilder);
        }

        private void SetModelRelations(ModelBuilder modelBuilder)
        {
            // Utilizator has many Anunturi
            modelBuilder.Entity<Anunt>()
                .HasOne<Utilizator>(u => u.Utilizator)
                .WithMany(a => a.AnunturiList)
                .HasForeignKey(u => u.IdUtilizator);
            /*
            // Servicii has many Anunturi
            modelBuilder.Entity<Anunt>()
                .HasOne<Serviciu>(s => s.Serviciu)
                .WithMany(a => a.AnunturiList)
                .HasForeignKey(a => a.IdServiciu);
            */
            // Utilizator has many FeedBacks
            modelBuilder.Entity<Feedback>()
                .HasOne<Utilizator>(u => u.Utilizator)
                .WithMany(f => f.FeedbacksList)
                .HasForeignKey(u => u.IdUtilizatorPrimit);
            /*
            // Utilizator has many AnunturiPrestate
            modelBuilder.Entity<AnuntPrestat>()
                .HasOne<Utilizator>(u => u.Utilizator)
                .WithMany(a => a.AnunturiPrestateList)
                .HasForeignKey(u => u.IdUtilizator);
            
            // Cautari has many Anunturi
            modelBuilder.Entity<Cautare>()
                .HasOne<Anunt>(a => a.Anunt)
                .WithMany(c => c.CautariList)
                .HasForeignKey(a => a.IdAnunt);
            
            // Cautari has many Utilizatori
            modelBuilder.Entity<Cautare>()
                .HasOne<Utilizator>(u => u.Utilizator)
                .WithMany(c => c.CautariList)
                .HasForeignKey(u => u.IdUtilizator);
            
            // UtilizatoriFavoriti has many Utilizatori
            modelBuilder.Entity<UtilizatorFavorit>()
                .HasOne<Utilizator>(u => u.Utilizator)
                .WithMany(u => u.UtilizatoriFavoritiList)
                .HasForeignKey(u => u.IdUtilizatorFavorit);
        */
        }

        private void SetIndexes(ModelBuilder modelBuilder)
        {
        }

        

    }
}