using SimpleInjector;
using System.Web.Mvc;
using System.Web.Routing;

namespace trycatch.web.Controllers
{
	public class BaseController : Controller
	{
		private readonly Container _container;

		public BaseController(Container container)
		{
			_container = container;
		}

		protected virtual ActionResult InvokeHttp404()
		{
			IController errorController = _container.GetInstance<CommonController>();

			var routeData = new RouteData();
			routeData.Values.Add("controller", "Common");
			routeData.Values.Add("action", "PageNotFound");

			errorController.Execute(new RequestContext(HttpContext, routeData));

			return new EmptyResult();
		}
	}
}