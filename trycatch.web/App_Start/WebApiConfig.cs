using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using System.Web.OData.Routing;
using System.Web.OData.Routing.Conventions;
using trycatch.Domain;

namespace trycatch.web
{
	public class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			ODataModelBuilder builder = new ODataConventionModelBuilder();
			builder.EntitySet<Article>("articles");
			config.MapODataServiceRoute(
				routeName: "ODataRoute",
				routePrefix: "api",
				model: builder.GetEdmModel());
		} 
	}
}