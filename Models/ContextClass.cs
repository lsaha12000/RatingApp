using Microsoft.EntityFrameworkCore;

namespace RatingApp.Models
{
    public class ContextClass:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-86JDIB7K\SQLEXPRESS03;Database=BookRating;Trusted_Connection=true;TrustServerCertificate=True;MultipleActiveResultSets=true");
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Raing> Rating { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
