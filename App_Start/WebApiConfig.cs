using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace HManAPI
{
    public static class WebApiConfig
    {
        private static string apiKey = "AIzaSyD797F3YmgHaOzJj2hlBs9ZHFDxdUefatU";

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
        public static string getApiKey()
        {
            return apiKey;
        }
    }
}