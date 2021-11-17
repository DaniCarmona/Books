using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [Required]
        [StringLength(512)]
        public string Title { get; set; }
        public string Description { get; set; }

        [DisplayName("Author")]
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public ICollection<BookCategory> BookCategories { get; set; }
    }
}
