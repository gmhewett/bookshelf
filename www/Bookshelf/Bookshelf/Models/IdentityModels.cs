namespace Bookshelf.Models
{
    using System.Data.Entity;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    // You can add profile data for the user by adding more properties to your BookshelfUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class BookshelfUser : IdentityUser
    {
        public int LibraryId { get; set; }

        public virtual Library Library { get; set; }

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

        public DbSet<Book> Books { get; set; }
        
        public static BookshelfDbContext Create()
        {
            return new BookshelfDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Library>()
                .HasRequired(l => l.Owner)
                .WithOptional(b => b.Library);

            modelBuilder.Entity<Book>()
                .HasRequired(b => b.Library)
                .WithMany(l => l.Books);

            base.OnModelCreating(modelBuilder);
        }
    }
}