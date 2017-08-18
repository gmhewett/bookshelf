namespace Bookshelf.Models
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    
    public class BookshelfDbContext : IdentityDbContext<BookshelfUser>
    {
        public BookshelfDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Library> Libraries { get; set; }
        
        public static BookshelfDbContext Create()
        {
            return new BookshelfDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Library>()
                .HasRequired(l => l.Owner)
                .WithMany(t => t.Libraries)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Library>()
                .HasMany(l => l.Students)
                .WithMany(s => s.Libraries);

            modelBuilder.Entity<Book>()
                .HasRequired(b => b.Library)
                .WithMany(l => l.Books)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}