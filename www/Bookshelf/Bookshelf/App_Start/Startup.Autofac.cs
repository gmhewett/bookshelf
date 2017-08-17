namespace Bookshelf
{
    using System.Reflection;
    using System.Web.Http;
    using Autofac;
    using Autofac.Integration.WebApi;
    using Owin;

    public partial class Startup
    {
        public IContainer ConfigureAutofac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new BookshelfModule());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            IContainer container = builder.Build();

            HttpConfiguration = new HttpConfiguration
            {
                DependencyResolver = new AutofacWebApiDependencyResolver(container)
            };

            app.UseAutofacMiddleware(container);
            return container;
        }
    }
}