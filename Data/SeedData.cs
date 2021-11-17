//#define TEST_PAGINATION_BOOKS

using Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Data
{
    public class SeedData
    {
        internal static void Populate(BooksContext booksContext)
        {
#if TEST_PAGINATION_BOOKS
            Author author = booksContext.Author.FirstOrDefault();

            if (author == null)
            {
                author = new Author { Name = "Anonymous" };
                booksContext.Add(author);
            }

            for(int i = 1; i <= 1000; i++)
            {
                booksContext.Add(
                    new Book
                    {
                        Title = "Book" + i,
                        Description = "Book Description" + i,
                        Author= author
                    }
                    
                    );
                
            }
            booksContext.SaveChanges;
#endif
        }
    }
}
