using System.Web.Mvc;

namespace trycatch.web.Controllers
{
	public class CommonController : Controller
	{
		public ActionResult PageNotFound()
		{
			Response.StatusCode = 404;
			Response.TrySkipIisCustomErrors = true;

			return View();
		}
	}
}