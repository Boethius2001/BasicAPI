using Microsoft.EntityFrameworkCore;

namespace BasicAPI
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; } // Kitap objelerinin koleksiyonu

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source=Library.db");
    }
}
