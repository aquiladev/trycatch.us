using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FluentValidation.Mvc;

namespace trycatch.web
{
	public class MvcApplication : HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
			ModelValidatorProviders.Providers.Add(new FluentValidationModelValidatorProvider());
		}
	}
}
