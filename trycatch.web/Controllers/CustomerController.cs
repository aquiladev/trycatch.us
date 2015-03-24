using System.Web.Mvc;
using trycatch.Services.Interfaces;
using trycatch.web.Models;

namespace trycatch.web.Controllers
{
	public class CustomerController : Controller
	{
		private readonly IWorkContext _workContext;
		private readonly ICustomerService _customerService;

		public CustomerController(IWorkContext workContext, 
			ICustomerService customerService)
		{
			_workContext = workContext;
			_customerService = customerService;
		}

		public ActionResult Register()
		{
			return View(PrepareCustomerModel());
		}

		[HttpPost]
		public ActionResult Register(CustomerModel customer)
		{
			if (ModelState.IsValid)
			{
				var current = _workContext.CurrentCustomer;
				current.LastName = customer.LastName;
				current.FirstName = customer.FirstName;
				current.Address = customer.Address;
				current.City = customer.City;
				current.Email = customer.Email;
				current.HousNumber = customer.HousNumber;
				current.Title = customer.Title;
				current.ZipCode = customer.ZipCode;
				current.IsGuest = false;
				_customerService.Update(current);

				return RedirectToAction("Cart", "ShoppingCart");
			}
			
			return View(PrepareCustomerModel());
		}

		private CustomerModel PrepareCustomerModel()
		{
			var customer = _customerService.Get(_workContext.CurrentCustomer.Id);

			return new CustomerModel
			{
				Id = customer.Id,
				Address = customer.Address,
				City = customer.City,
				Email = customer.Email,
				FirstName = customer.FirstName,
				HousNumber = customer.HousNumber,
				LastName = customer.LastName,
				Title = customer.Title,
				ZipCode = customer.ZipCode
			};
		}
	}
}