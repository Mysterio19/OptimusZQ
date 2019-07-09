using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OptimusZQ.Web.AppStart
{
    internal class RoutesConfigurator
    {
        private IRouteBuilder _builder;
        private string[] _templatesPathes;

        private List<dynamic> ParseTemplates()
        {
            List<dynamic> routesCollection = new List<dynamic>();

            foreach (var path in _templatesPathes)
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string json = reader.ReadToEnd();
                    routesCollection.Add(JsonConvert.DeserializeObject(json));
                }
            }

            return routesCollection;
        }

        private void MapRoutes(List<dynamic> routesCollection)
        {
            foreach (var routeRule in 
                     (from dynamic rule in
                     (from dynamic routes in routesCollection 
                     select routes.rules) select rule.Children()))
            {
                _builder.MapRoute(routeRule.Name as string,
                    routeRule.Url as string, 
                    new { controller = routeRule.Controller, action = routeRule.Action });
            }
        }
        public RoutesConfigurator(IRouteBuilder builder, params string[] templatesPathes)
        {
            _builder = builder;
            _templatesPathes = templatesPathes;
        }

        public void BuildRoutesUsingTemplates()
        {
            List<dynamic> routesCollection = ParseTemplates();
            MapRoutes(routesCollection);
        }

    }
}
