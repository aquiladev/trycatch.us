using System.Collections.Generic;

namespace trycatch.web.Models
{
	public class ShoppingCartModel
	{
		public ShoppingCartModel()
		{
			Items = new List<ShoppingCartItemModel>();
		}

		public decimal SubTotal { get; set; }
		public decimal TotalVat { get; set; }
		public decimal Total { get; set; }

		public IList<ShoppingCartItemModel> Items { get; set; }
	}
}