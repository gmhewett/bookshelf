﻿using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace Bookshelf.Models
{
    // You can add profile data for the user by adding more properties to your BookshelfUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class BookshelfUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<BookshelfUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class BookshelfDbContext : IdentityDbContext<BookshelfUser>
    {
        public BookshelfDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static BookshelfDbContext Create()
        {
            return new BookshelfDbContext();
        }

        public System.Data.Entity.DbSet<Bookshelf.Models.Book> Books { get; set; }
    }
}