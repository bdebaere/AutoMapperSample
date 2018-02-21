using System.Linq;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using AutoMapperSample.Controllers;

namespace AutoMapperSample
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes.
            config.MapHttpAttributeRoutes();

            // Replace the standard api routing with the OData routing.
            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<DtoItem>("Items");
            config.MapODataServiceRoute("ODataRoute", "odata", builder.GetEdmModel());

            // Enables the OData filters.
            config
                .Count()
                .Filter()
                .OrderBy()
                .Expand()
                .Select()
                .MaxTop(null);
        }
    }
}
