using System;
using System.Linq;
using trycatch.Data;
using trycatch.Domain;
using trycatch.Services.Interfaces;

namespace trycatch.Services
{
	public class ShoppingCartService : IShoppingCartService
	{
		private readonly IRepository<ShoppingCartItem> _shoppingCartItemRepository;
		private readonly ICustomerService _customerService;

		public ShoppingCartService(IRepository<ShoppingCartItem> shoppingCartItemRepository,
			ICustomerService customerService)
		{
			_shoppingCartItemRepository = shoppingCartItemRepository;
			_customerService = customerService;
		}

		public IQueryable<ShoppingCartItem> GetAll()
		{
			return _shoppingCartItemRepository.GetAll();
		}

		public bool Add(Customer customer, Article article)
		{
			if (customer == null)
				throw new ArgumentNullException("customer");

			if (article == null)
				throw new ArgumentNullException("article");

			var shoppingCartItem = _shoppingCartItemRepository.GetAll()
				.FirstOrDefault(x => x.CustomerId == customer.Id && x.ArticleId == article.Id);

			if (shoppingCartItem != null)
			{
				return false;
			}

			shoppingCartItem = new ShoppingCartItem
			{
				Article = article
			};
			customer.ShoppingCartItems.Add(shoppingCartItem);
			_customerService.Update(customer);

			return true;
		}

		public void RemoveCart(Customer customer)
		{
			var items = customer.ShoppingCartItems.ToList();
			foreach (var item in items)
			{
				_shoppingCartItemRepository.Delete(item);
			}
		}
	}
}
