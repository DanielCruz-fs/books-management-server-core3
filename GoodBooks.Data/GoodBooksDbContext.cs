using GoodBooks.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoodBooks.Data
{
    public class GoodBooksDbContext : DbContext
    {
        public GoodBooksDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookReview> BookReviews { get; set; }
    }
}
