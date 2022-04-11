using Microsoft.EntityFrameworkCore;
using ProjectLicenta.Web.LicentaApi.Core.Models;

namespace ProjectLicenta.Web.LicentaApi.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SetIndexes(modelBuilder);
        }

        private void SetIndexes(ModelBuilder modelBuilder)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}