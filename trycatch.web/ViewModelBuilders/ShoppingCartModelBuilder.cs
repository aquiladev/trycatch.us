using System;
using System.Linq;
using trycatch.Services.Interfaces;
using trycatch.web.Models;

namespace trycatch.web.ViewModelBuilders
{
	public class ShoppingCartModelBuilder
	{
		private readonly IWorkContext _workContext;
		private readonly IArticleService _articleService;

		public ShoppingCartModelBuilder(IWorkContext workContext,
			IArticleService articleService)
		{
			_workContext = workContext;
			_articleService = articleService;
		}

		public ShoppingCartModel Build()
		{
			var articlesIds = _workContext.CurrentCustomer.ShoppingCartItems.Select(x => x.ArticleId).ToArray();
			var articles = _articleService.GetAll()
				.Where(a => articlesIds.Contains(a.Id));

			var items = articles
				.Select(a => new ShoppingCartItemModel
				{
					ArticleId = a.Id,
					ArticleName = a.Name,
					ArticlePrice = a.Price
				})
				.ToList();
			var subTotal = articles.Sum(x => x.Price);

			return new ShoppingCartModel
			{
				Items = items,
				SubTotal = subTotal,
				TotalVat = subTotal * Convert.ToDecimal(0.3),
				Total = subTotal * Convert.ToDecimal(1.3)
			};
		}
	}
}