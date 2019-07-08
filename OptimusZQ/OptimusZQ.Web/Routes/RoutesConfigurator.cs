using Microsoft.AspNetCore.Routing;

namespace OptimusZQ.Web.Routes
{
    internal class RoutesConfigurator
    {
        private IRouteBuilder _builder;
        private string[] _templatesPathes;
        public RoutesConfigurator(IRouteBuilder builder, params string[] templatesPathes)
        {
            _builder = builder;
            _templatesPathes = templatesPathes;
        }

        public void BuildRoutesUsingTemplates()
        {
            //routes.MapRoute(
            //    name: "default",
            //    template: "{controller}/{action=Index}/{id?}");
        }

    }
}
