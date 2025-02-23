using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace BasicAPI
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; } // Kitap objelerinin koleksiyonu
        
        public BookContext(DbContextOptions<BookContext> options) : base(options) { }

        //sqlite veritabani olusturmak icin
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source=Library.db");
    }
}
