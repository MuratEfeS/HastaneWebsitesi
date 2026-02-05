using Microsoft.EntityFrameworkCore;
using HastaneDoktorListesi.Models;
using HastaneBilgiListeleri.Models;

namespace HastaneDoktorListesi.Data
{
    public class HastaneDBContext : DbContext
    {
        public DbSet<Hasta> Hastalar { get; set; }
        public DbSet<Doktor> Doktorlar { get; set; }
        public DbSet<Hastalik> Hastaliklar {  get; set; }
        public DbSet<Ilac> Ilaclar { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data source=.; initial catalog= Hastane; integrated security=true; trust server certificate=true");

        }
    }
}