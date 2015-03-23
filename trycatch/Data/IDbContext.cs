using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace trycatch.Data
{
	public interface IDbContext : IObjectContextAdapter
	{
		IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;

		int SaveChanges();
	}
}
