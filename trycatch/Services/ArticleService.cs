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

		public IQueryable<Article> GetAll()
		{
			return _articleRepository.GetAll();
		}

		public Article Get(int id)
		{
			return _articleRepository.Find(id);
		}
	}
}
