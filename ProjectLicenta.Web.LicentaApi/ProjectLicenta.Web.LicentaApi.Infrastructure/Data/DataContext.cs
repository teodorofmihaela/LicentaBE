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
        public DbSet<AnuntFavorit> UtilizatoriFavoriti { get; set; }
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
            UtilizatorHasManyAnunturi(modelBuilder);
            ServiciuHasManyAnunturi(modelBuilder);
            ServiciuHasManyFeedbacks(modelBuilder);
            UtilizatorGivesManyFeedbacksToAnunturi(modelBuilder);
            AnuntHasManyCautari(modelBuilder);
            UtilizatorHasManyCautari(modelBuilder);
            AnuntHasManyAnunturiPrestate(modelBuilder);
            UtilizatorHasBoughtManyAnunturiPrestate(modelBuilder);
            UtilizatorHasManyAnunturiFavorite(modelBuilder);
        }

        private void UtilizatorHasManyAnunturiFavorite(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnuntFavorit>()
                .HasOne<Utilizator>(a => a.Utilizator)
                .WithMany(u => u.AnunturiFavoriteList)
                .HasForeignKey(a => a.UtilizatorId);
            
            modelBuilder.Entity<AnuntFavorit>()
                .HasOne<Anunt>(a => a.Anunt)
                .WithMany()
                .HasForeignKey(a => a.AnuntId);
        }

        private void UtilizatorHasBoughtManyAnunturiPrestate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnuntPrestat>()
                .HasOne<Utilizator>(a => a.Utilizator)
                .WithMany(u=>u.AnunturiPrestateList)
                .HasForeignKey(a => a.UtilizatorId);
        }

        private void AnuntHasManyAnunturiPrestate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnuntPrestat>()
                .HasOne<Anunt>(a => a.Anunt)
                .WithMany()
                .HasForeignKey(a => a.AnuntId);
        }

        private void UtilizatorHasManyCautari(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cautare>()
                .HasOne<Utilizator>(c => c.Utilizator)
                .WithMany()
                .HasForeignKey(c => c.UtilizatorId);
        }

        private void AnuntHasManyCautari(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cautare>()
                .HasOne<Anunt>()
                .WithMany()
                .HasForeignKey(c => c.AnuntId);
        }

        private void UtilizatorHasManyAnunturi(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Anunt>()
                .HasOne<Utilizator>(a => a.Utilizator)
                .WithMany(u => u.AnunturiList)
                .HasForeignKey(a => a.UtilizatorId);
        }

        private void UtilizatorGivesManyFeedbacksToAnunturi(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Feedback>()
                .HasOne<Utilizator>(f => f.Utilizator)
                .WithMany(u => u.FeedbacksDateList)
                .HasForeignKey(f => f.UtilizatorId);
            
            modelBuilder.Entity<Feedback>()
                .HasOne<Anunt>(f => f.Anunt)
                .WithMany()
                .HasForeignKey(f => f.AnuntId);
        }

        private void ServiciuHasManyFeedbacks(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Feedback>()
                .HasOne<Serviciu>(f => f.Serviciu)
                .WithMany()
                .HasForeignKey(f => f.ServiciuId);
        }

        public void ServiciuHasManyAnunturi(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anunt>()
                .HasOne<Serviciu>(a => a.Serviciu)
                .WithMany(s => s.AnunturiList)
                .HasForeignKey(a => a.ServiciuId);
        }

        private void SetIndexes(ModelBuilder modelBuilder)
        {
        }

        

    }
}