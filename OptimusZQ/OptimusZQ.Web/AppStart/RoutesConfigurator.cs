using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using OptimusZQ.Common.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OptimusZQ.Web.AppStart
{
    internal class RoutesConfigurator
    {
        private IRouteBuilder _builder;
        private string[] _templatesPathes;

        private List<RoutesSet> ParseTemplates()
        {
            List<RoutesSet> routesCollection = new List<RoutesSet>();

            foreach (var path in _templatesPathes)
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string json = reader.ReadToEnd();
                    routesCollection.Add(JsonConvert.DeserializeObject<RoutesSet>(json));
                }
            }

            return routesCollection;
        }

        private void MapRoutes(List<RoutesSet> routesCollection)
        {
            var routesRules = routesCollection.SelectMany(x => x.Rules);

            foreach (var routeRule in routesRules)
            {
                _builder.MapRoute(routeRule.Name,
                    routeRule.Url,
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
            List<RoutesSet> routesCollection = ParseTemplates();
            MapRoutes(routesCollection);
        }

    }
}
