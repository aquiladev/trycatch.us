using System;
using System.Linq;

namespace trycatch.Data
{
	public interface IRepository<TEntity>
	{
		IQueryable<TEntity> GetAll();
		TEntity Find(Guid id);
		TEntity Add(TEntity entity);
		TEntity Update(TEntity entity);
		void Delete(TEntity entity);
	}
}
