using System.Linq;
using trycatch.Domain;

namespace trycatch.Services.Interfaces
{
	public interface IShoppingCartService
	{
		IQueryable<ShoppingCartItem> GetAll(); 
		bool Add(Customer customer, Article article);
		void RemoveCart(Customer customer);
	}
}
