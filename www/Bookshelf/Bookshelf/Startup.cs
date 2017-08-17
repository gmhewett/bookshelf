using Microsoft.Owin;

[assembly: OwinStartup(typeof(Bookshelf.Startup))]

namespace Bookshelf
{
    using System.Web.Http;
    using Autofac;
    using Owin;

    public partial class Startup
    {
        public static HttpConfiguration HttpConfiguration { get; set; }

        public void Configuration(IAppBuilder app)
        {
            IContainer container = ConfigureAutofac(app);
            ConfigureAuth(app, container);
            ConfigureWebApi(app);
            ConfigureJson(app);
        }
    }
}
