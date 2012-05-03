using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using Raven.Client.Document;
using Raven.Client.Indexes;

namespace personal_website
{
  public class MvcApplication : System.Web.HttpApplication
  {
    public static DocumentStore Store;

    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
      filters.Add(new HandleErrorAttribute());
    }

    public static void RegisterRoutes(RouteCollection routes)
    {
      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

      routes.MapRoute(
        "Default",
        "{controller}/{action}/{*id}",
        new 
        { 
          controller  = "Home", 
          action      = "Index", 
          id          = UrlParameter.Optional 
        }
      );

    }

    protected void Application_Start()
    {
      AreaRegistration.RegisterAllAreas();

      RegisterGlobalFilters(GlobalFilters.Filters);
      RegisterRoutes(RouteTable.Routes);

      Store = new DocumentStore { ConnectionStringName = "RavenDB" };
      Store.Initialize();

      IndexCreation.CreateIndexes(Assembly.GetCallingAssembly(), Store);
    }
  }
}