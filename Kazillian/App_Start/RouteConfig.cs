﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Kazillian
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
            name: "TOS",
            url: "terms-of-service",
            defaults: new { controller = "Home", action = "TermsOfService" }
        );
            routes.MapRoute(
            name: "Privacy",
            url: "privacy",
            defaults: new { controller = "Home", action = "Privacy" }
        );
            routes.MapRoute(
             name: "MyProfile",
             url: "me",
             defaults: new { controller = "Profile", action = "Me" }
         );
            routes.MapRoute(
              name: "SignUp",
              url: "signup/{id}",
              defaults: new { controller = "Account", action = "SignUp", id = UrlParameter.Optional } 
          );

            routes.MapRoute(
              name: "SellerProfile",
              url: "seller/{id}",
              defaults: new { controller = "Profile", action = "Seller", id = UrlParameter.Optional }


          );

            routes.MapRoute(
              name: "EmployerProfile",
              url: "employer/{id}",
              defaults: new { controller = "Profile", action = "Employer", id = UrlParameter.Optional }


          );

            routes.MapRoute(
               name: "JobProfile",
               url: "job/{id}",
               defaults: new { controller = "Profile", action = "Job", id = UrlParameter.Optional }
             
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
