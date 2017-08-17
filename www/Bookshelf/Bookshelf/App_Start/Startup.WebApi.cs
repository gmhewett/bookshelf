namespace Bookshelf
{
    using System.Web.Http;
    using Microsoft.Owin.Security.OAuth;
    using Owin;

    public partial class Startup
    {
        public void ConfigureWebApi(IAppBuilder app)
        {
            HttpConfiguration.SuppressDefaultHostAuthentication();
            HttpConfiguration.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            HttpConfiguration.MapHttpAttributeRoutes();
            HttpConfiguration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            app.UseAutofacWebApi(HttpConfiguration);
            app.UseWebApi(HttpConfiguration);
        }
    }
}