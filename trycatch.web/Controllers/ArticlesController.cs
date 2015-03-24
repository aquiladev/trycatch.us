using System.Linq;
using System.Web.Http;
using System.Web.OData;
using trycatch.Domain;
using trycatch.Services.Interfaces;

namespace trycatch.web.Controllers
{
	public class ArticlesController : ODataController
	{
		private readonly IArticleService _articleService;

		public ArticlesController(IArticleService articleService)
		{
			_articleService = articleService;
		}

		[EnableQuery]
		public IQueryable<Article> Get()
		{
			return _articleService.GetAll();
		}

		[EnableQuery]
		public SingleResult<Article> Get([FromODataUri] int key)
		{
			IQueryable<Article> result = _articleService.GetAll().Where(p => p.Id == key);
			return SingleResult.Create(result);
		}
	}
}