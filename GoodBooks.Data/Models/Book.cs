using System;
using System.Collections.Generic;
using System.Text;

namespace GoodBooks.Data.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public ICollection<BookReview> BookReviews { get; set; }
    }
}
