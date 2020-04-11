using Microsoft.EntityFrameworkCore;

namespace ValidatieBackend.data
{
    public class ValidatieContext : DbContext
    {
        public ValidatieContext(DbContextOptions<ValidatieContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed
            modelBuilder.Entity<Adres>().HasData(new Adres { Id = 1, Straat = "Blastraat", PostCode = "9999AA", Huisnummer = 39, Gemeente = "Blabla" });
        }
        public DbSet<Adres> Adressen { get; set; }
    }
}