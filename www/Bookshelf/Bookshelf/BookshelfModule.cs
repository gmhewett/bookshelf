namespace Bookshelf
{
    using System;
    using Autofac;
    using Bookshelf.Clients.GoogleBooksApi;
    using Bookshelf.Config;
    using Bookshelf.Loggers;
    using Bookshelf.Models;
    using Bookshelf.Services;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin.Security;
    using Microsoft.Owin.Security.DataHandler;
    using Microsoft.Owin.Security.DataHandler.Serializer;
    using Microsoft.Owin.Security.DataProtection;

    public sealed class BookshelfModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BookshelfDbContext>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<BookshelfUserManager>().AsSelf().InstancePerLifetimeScope();
            builder.Register(c => new UserStore<BookshelfUser>(c.Resolve<BookshelfDbContext>())).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<TicketDataFormat>().As<ISecureDataFormat<AuthenticationTicket>>();
            builder.RegisterType<TicketSerializer>().As<IDataSerializer<AuthenticationTicket>>();
            builder.Register(c => new DpapiDataProtectionProvider(Guid.NewGuid().ToString())).As<IDataProtectionProvider>();
            builder.Register(c => c.Resolve<IDataProtectionProvider>().Create(Guid.NewGuid().ToString())).As<IDataProtector>();
            builder.Register(c => new IdentityFactoryOptions<BookshelfUserManager>
            {
                DataProtectionProvider = c.Resolve<IDataProtectionProvider>()
            });

            builder.RegisterType<BookshelfConfig>().As<IBookshelfConfig>();
            builder.RegisterType<BookshelfLogger>().As<IBookshelfLogger>();

            builder.RegisterType<BookService>().As<IBookService>();
            builder.RegisterType<LibraryService>().As<ILibraryService>();
            builder.RegisterType<RentalService>().As<IRentalService>();

            builder.RegisterType<GoogleBooksApiClient>().As<IGoogleBooksApiClient>().InstancePerLifetimeScope();
        }
    }
}