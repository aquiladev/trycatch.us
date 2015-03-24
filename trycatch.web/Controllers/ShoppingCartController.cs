using System.Web.Mvc;
using trycatch.Services.Interfaces;
using trycatch.web.ViewModelBuilders;

namespace trycatch.web.Controllers
{
	public class ShoppingCartController : Controller
	{
		private readonly IWorkContext _workContext;
		private readonly IArticleService _articleService;
		private readonly IShoppingCartService _shoppingCartService;
		private readonly ShoppingCartModelBuilder _buidler;

		public ShoppingCartController(IWorkContext workContext,
			IArticleService articleService,
			IShoppingCartService shoppingCartService,
			ShoppingCartModelBuilder buidler)
		{
			_workContext = workContext;
			_articleService = articleService;
			_shoppingCartService = shoppingCartService;
			_buidler = buidler;
		}

		public ActionResult Cart()
		{
			if (_workContext.CurrentCustomer.ShoppingCartItems.Count == 0)
			{
				return RedirectToAction("Index", "Home");
			}

			return View(_buidler.Build());
		}

		[HttpPost]
		public JsonResult AddToCart(int articleId)
		{
			var article = _articleService.Get(articleId);
			if (article == null)
			{
				return Json(new
				{
					success = false,
					message = "No article found with the specified ID"
				});
			}
			var result = _shoppingCartService.Add(_workContext.CurrentCustomer, article);

			return Json(new
			{
				success = result,
				message = result ? "The article added to the cart" : "The article didn't add to the cart"
			});
		}
	}
}