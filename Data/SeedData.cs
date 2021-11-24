//#define TEST_PAGINATION_BOOKS

using Books.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Data
{
    public class SeedData
    {
        private const string ADMIN_EMAIL = "admin@ipg.pt";
        private const string ADMIN_PASSWORD = "Secret123$";

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

        internal static void CreateDefaultAdmin(UserManager<IdentityUser> userManager)
        {
            EnsureUserIsCreatedAsync(userManager, ADMIN_EMAIL, ADMIN_PASSWORD).Wait();
        }

        private static async Task EnsureUserIsCreatedAsync(UserManager<IdentityUser> userManager, string email, string password)
        {
            var user = await userManager.FindByNameAsync(email);

            if (user != null) return;

            user = new IdentityUser
            {
                UserName = email,
                Email = email
            };

            await userManager.CreateAsync(user, password);
        }

        internal static void PopulateUsers(UserManager<IdentityUser> userManager)
        {
        }
    }
}
