﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Ploeh.Samples.Commerce.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // The following IgnoreRoute is needed for browsers like Chrome:
            // http://stackoverflow.com/questions/719678/custom-controller-factory-dependency-injection-structuremap-problems-with-asp
            routes.IgnoreRoute("{*favicon}", new {favicon = @"(.*/)?favicon.ico(/.*)?"});



            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            MvcApplication.RegisterRoutes(RouteTable.Routes);

            var root = new CompositionRoot();
            ControllerBuilder.Current.SetControllerFactory(root.ControllerFactory);
        }
    }
}