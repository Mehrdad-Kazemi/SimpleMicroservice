using BookService.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookService.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=BookMicroservices;Integrated Security=True");
        }
    }
}
