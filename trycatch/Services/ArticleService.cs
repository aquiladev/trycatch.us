using System.Linq;
using trycatch.Data;
using trycatch.Domain;
using trycatch.Services.Interfaces;

namespace trycatch.Services
{
	public class ArticleService : IArticleService
	{
		private readonly IRepository<Article> _articleRepository;

		public ArticleService(IRepository<Article> articleRepository)
		{
			_articleRepository = articleRepository;
		}

		public IQueryable<Article> Get()
		{
			return _articleRepository.GetAll();
		}
	}
}
