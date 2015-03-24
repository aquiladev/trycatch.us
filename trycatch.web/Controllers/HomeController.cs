using System.Web.Mvc;
using trycatch.web.ViewModelBuilders;

namespace trycatch.web.Controllers
{
	public class HomeController : Controller
	{
		private readonly HomepageModelBuilder _viewModelBuilder;

		public HomeController(HomepageModelBuilder viewModelBuilder)
		{
			_viewModelBuilder = viewModelBuilder;
		}

		public ActionResult Index()
		{
			return View(_viewModelBuilder.Build());
		}
	}
}