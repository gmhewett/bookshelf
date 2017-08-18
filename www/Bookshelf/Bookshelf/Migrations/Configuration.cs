namespace Bookshelf.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Bookshelf.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<BookshelfDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Bookshelf.Models.BookshelfDbContext";
        }

        protected override void Seed(BookshelfDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == RoleNames.AdminRole))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = RoleNames.AdminRole };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == RoleNames.TeacherRole))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = RoleNames.TeacherRole };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "gregory.hewett@me.com"))
            {
                var store = new UserStore<BookshelfUser>(context);
                var manager = new UserManager<BookshelfUser>(store);
                var user = new BookshelfUser
                {
                    Id = "1",
                    UserName = "gregory.hewett@me.com",
                    Email = "gregory.hewett@me.com"
                };

                manager.Create(user, "changeme!");
                manager.AddToRole(user.Id, RoleNames.AdminRole);
            }
            else
            {
                var store = new UserStore<BookshelfUser>(context);
                var manager = new UserManager<BookshelfUser>(store);

                if (!manager.IsInRole("1", RoleNames.AdminRole))
                {
                    manager.AddToRole("1", RoleNames.AdminRole);
                }
            }

            if (!context.Users.Any(u => u.UserName == "jenni.l.hewett@gmail.com"))
            {
                var store = new UserStore<BookshelfUser>(context);
                var manager = new UserManager<BookshelfUser>(store);
                var user = new Teacher
                {
                    Id = "2",
                    UserName = "jenni.l.hewett@gmail.com",
                    Email = "jenni.l.hewett@gmail.com"
                };

                manager.Create(user, "Password1!");
                manager.AddToRole(user.Id, RoleNames.TeacherRole);
            }
            else
            {
                var store = new UserStore<BookshelfUser>(context);
                var manager = new UserManager<BookshelfUser>(store);

                if (!manager.IsInRole("2", RoleNames.TeacherRole))
                {
                    manager.AddToRole("2", RoleNames.TeacherRole);
                }
            }
        }
    }
}
