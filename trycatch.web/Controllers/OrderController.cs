using System.Web.Mvc;
using trycatch.Services.Interfaces;

namespace trycatch.web.Controllers
{
	public class OrderController : Controller
	{
		private readonly IWorkContext _workContext;
		private readonly IShoppingCartService _shoppingCartService;

		public OrderController(IWorkContext workContext,
			IShoppingCartService shoppingCartService)
		{
			_workContext = workContext;
			_shoppingCartService = shoppingCartService;
		}

		public ActionResult SaveOrder()
		{
			if (_workContext.CurrentCustomer.ShoppingCartItems.Count == 0)
			{
				return RedirectToAction("Index", "Home");
			}

			if (_workContext.CurrentCustomer.IsGuest)
			{
				return RedirectToAction("Register", "Customer");
			}

			_shoppingCartService.RemoveCart(_workContext.CurrentCustomer);

			return RedirectToAction("OrderResult");
		}

		public ActionResult OrderResult()
		{
			return View();
		}
	}
}