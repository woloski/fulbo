using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Data.Entity;
using Fulbo.Models;

namespace Fulbo
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            Database.SetInitializer<FulboContext>(new DbInitializer());
        }
    }

    public class DbInitializer : DropCreateDatabaseAlways<FulboContext>
    {
        private IEnumerable<int> Fixtures
        {
            get
            {
                return new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
            }
        }

        private IEnumerable<string> Teams
        {
            get
            {
                return new[] { "River Plate",
                                                "Boca Juniors",
                                                "Racing",
                                                "Independiente"
                            };
            }
        }

        protected override void Seed(FulboContext context)
        {
            Fixtures.ToList().ForEach(f => context.Fixtures.Add(new Fixture { Number = f, Season = 1 }));
            Teams.ToList().ForEach(t => context.Teams.Add(new Team { Name = t }));
            
            base.Seed(context);
        }
    }
}