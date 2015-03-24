using System.Web.Mvc;
using SimpleInjector;
using trycatch.Services.Interfaces;
using trycatch.web.Models;

namespace trycatch.web.Controllers
{
	public class ArticleController : BaseController
	{
		private readonly IArticleService _articleService;

		public ArticleController(Container container, IArticleService articleService)
			: base(container)
		{
			_articleService = articleService;
		}

		public ActionResult Overview()
		{
			return View();
		}

		public ActionResult Index(int id)
		{
			var article = _articleService.Get(id);
			if (article == null)
			{
				return InvokeHttp404();
			}

			return View(new ArticleModel
			{
				Id = article.Id,
				Name = article.Name,
				Description = article.Description,
				Price = article.Price
			});
		}
	}
}