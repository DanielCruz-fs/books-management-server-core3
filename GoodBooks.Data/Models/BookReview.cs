using System;
using System.Collections.Generic;
using System.Text;

namespace GoodBooks.Data.Models
{
    public class BookReview
    {
        public int Id { get; set; }
        public string ReviewAuthor { get; set; }
        public string ReviewContent { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
