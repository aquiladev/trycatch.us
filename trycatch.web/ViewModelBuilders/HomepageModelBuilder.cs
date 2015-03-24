using System.Data.Entity;
using System.Linq;
using trycatch.Services;
using trycatch.web.Models;

namespace trycatch.web.ViewModelBuilders
{
	public class HomepageModelBuilder
	{
		private readonly ArticleService _articleService;

		public HomepageModelBuilder(ArticleService articleService)
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