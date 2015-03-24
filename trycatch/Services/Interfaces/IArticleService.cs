using System.Linq;
using trycatch.Domain;

namespace trycatch.Services.Interfaces
{
	public interface IArticleService
	{
		IQueryable<Article> GetAll();
		Article Get(int id);
	}
}