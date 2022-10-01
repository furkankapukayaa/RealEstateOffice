using System.Data.Entity;

namespace RealEstateOffice.Models
{
    public class dbContext : DbContext
    {
        public dbContext() : base("name=Context")
        {
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Advert> Adverts { get; set; }
    }
}