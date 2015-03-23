using System.Linq;
using trycatch.Domain;

namespace trycatch.Services.Interfaces
{
	public interface IArticleService
	{
		IQueryable<Article> Get();
	}
}