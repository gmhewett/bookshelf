namespace Bookshelf.Migrations
{
    using System.Data.Entity.Migrations;
    using Bookshelf.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<BookshelfDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Bookshelf.Models.BookshelfDbContext";
        }

        protected override void Seed(BookshelfDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
