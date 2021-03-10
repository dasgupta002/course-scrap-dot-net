using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace tutorialspoint_test_API_framework
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "ApiV1",
                routeTemplate: "api/v1/{controller}/{id}",
                defaults: new { controller = "office", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "ApiV2",
                routeTemplate: "api/v2/{controller}/{id}",
                defaults: new { controller = "updatedOffices", id = RouteParameter.Optional }
            );
        }
    }
}
