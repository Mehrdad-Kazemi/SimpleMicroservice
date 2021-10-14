using Microsoft.EntityFrameworkCore;
using ReservationService.Database.Entities;

namespace ReservationService.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=ReservationMicroservices;Integrated Security=True");
        }
    }
}
