using Project_MVC.App_Start;
using System.Web.Mvc;
using System.Web.Routing;

namespace Project_MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //automapping
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<AppStartMappingConfiguration>();
            });
        }
    }
}