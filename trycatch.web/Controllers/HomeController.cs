using System.Web.Mvc;
using trycatch.Services;

namespace trycatch.web.Controllers
{
	public class HomeController : Controller
	{
		private readonly ArticleService _articleService;

		public HomeController(ArticleService articleService)
		{
			_articleService = articleService;
		}

		public ActionResult Index()
		{
			var d = _articleService.Get();
			return View();
		}
	}
}