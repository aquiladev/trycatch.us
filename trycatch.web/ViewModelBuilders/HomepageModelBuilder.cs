using System.Data.Entity;
using System.Linq;
using trycatch.Services.Interfaces;
using trycatch.web.Models;

namespace trycatch.web.ViewModelBuilders
{
	public class HomepageModelBuilder
	{
		private readonly IArticleService _articleService;

		public HomepageModelBuilder(IArticleService articleService)
		{
			_articleService = articleService;
		}

		public HomepageModel Build()
		{
			var articles = _articleService.GetAll()
				.Take(() => 12)
				.Select(x => new ArticleOverviewModel
				{
					Id = x.Id,
					Name = x.Name,
					Price = x.Price
				})
				.ToList();

			return new HomepageModel
			{
				Articles = articles
			};
		}
	}
}