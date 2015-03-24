using System;
using System.Web;
using trycatch.Domain;
using trycatch.Services.Interfaces;

namespace trycatch
{
	public class WorkContext : IWorkContext
	{
		private const string CustomerCookieName = "TryCatch.Customer";
		private const int CookieExpires = 24 * 365;

		private readonly HttpContextBase _httpContext;
		private readonly ICustomerService _customerService;

		public WorkContext(HttpContextBase httpContext,
			ICustomerService customerService)
		{
			_httpContext = httpContext;
			_customerService = customerService;
		}

		private Customer _cachedCustomer;
		public Customer CurrentCustomer
		{
			get
			{
				Customer customer = null;
				var customerCookie = GetCustomerCookie();
				if (customerCookie != null && !String.IsNullOrEmpty(customerCookie.Value))
				{
					int customerId = Convert.ToInt32(customerCookie.Value);
					var customerByCookie = _customerService.Get(customerId);
					if (customerByCookie != null)
						customer = customerByCookie;
				}

				if (customer == null)
				{
					customer = _customerService.InsertGuest();
				}

				SetCustomerCookie(customer.Id);
				_cachedCustomer = customer;

				return _cachedCustomer;
			}
			set { SetCustomerCookie(value.Id); }
		}

		protected virtual HttpCookie GetCustomerCookie()
		{
			if (_httpContext == null || _httpContext.Request == null)
				return null;

			return _httpContext.Request.Cookies[CustomerCookieName];
		}

		protected virtual void SetCustomerCookie(int customerId)
		{
			if (_httpContext != null && _httpContext.Response != null)
			{
				var cookie = new HttpCookie(CustomerCookieName)
				{
					HttpOnly = true,
					Value = customerId.ToString(),
					Expires = customerId == 0 ? DateTime.Now.AddMonths(-1) : DateTime.Now.AddHours(CookieExpires)
				};

				_httpContext.Response.Cookies.Remove(CustomerCookieName);
				_httpContext.Response.Cookies.Add(cookie);
			}
		}
	}
}