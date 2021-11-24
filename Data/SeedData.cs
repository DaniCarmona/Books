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
        private const string ROLE_ADMIN = "admin";
        private const string ROLE_PRODUCT_MANAGER = "product_manager";
        private const string ROLE_COSTUMER = "costumer";

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
            EnsureUserIsCreatedAsync(userManager, ADMIN_EMAIL, ADMIN_PASSWORD, ROLE_ADMIN).Wait();
        }

        private static async Task EnsureUserIsCreatedAsync(UserManager<IdentityUser> userManager, string email, string password)
        {
            var user = await userManager.FindByNameAsync(email);

            if (user == null)
            {

                user = new IdentityUser
                {
                    UserName = email,
                    Email = email
                };

                await userManager.CreateAsync(user, password);
            }

            if (await userManager.IsInRoleAsync(user, role)) return;
            await userManager.AddToRoleAsync(user, role);
        }

        internal static void PopulateUsers(UserManager<IdentityUser> userManager)
        {
            EnsureUserIsCreatedAsync(userManager, "john@ipg.pt", ROLE_COSTUMER).Wait();
            EnsureUserIsCreatedAsync(userManager, "mary@ipg.pt", ROLE_PRODUCT_MANAGER).Wait();
        }
        internal static void CreateRoles(RoleManager<IdentityUser> roleManager)
        {
            EnsureRoleIsCreatedAsync(roleManager, ROLE_ADMIN).Wait();
            EnsureRoleIsCreatedAsync(roleManager, ROLE_PRODUCT_MANAGER).Wait();
            EnsureRoleIsCreatedAsync(roleManager, ROLE_COSTUMER).Wait();
        }

        private static async Task EnsureRoleIsCreatedAsync (RoleManager<IdentityUser> roleManager, string role)
        {
            if (await roleManager.RoleExistsAsync(role)) return;

            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}
