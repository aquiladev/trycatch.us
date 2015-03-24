using System.Collections.Generic;

namespace trycatch.web.Models
{
	public class HomepageModel
	{
		public HomepageModel()
		{
			Articles = new List<ArticleOverviewModel>();
		}

		public IList<ArticleOverviewModel> Articles { get; set; }
	}
}