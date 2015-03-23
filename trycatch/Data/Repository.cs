using System;
using System.Data.Entity;
using System.Linq;

namespace trycatch.Data
{
	internal class Repository<T> : IRepository<T> where T : BaseEntity
	{
		private readonly IDbContext _context;

		private IDbSet<T> _entities;
		private IDbSet<T> Entities
		{
			get { return _entities ?? (_entities = _context.Set<T>()); }
		}

		public Repository(IDbContext dbContext)
		{
			_context = dbContext;
		}

		public IQueryable<T> GetAll()
		{
			return Entities;
		}

		public T Find(Guid id)
		{
			return Entities.Find(id);
		}

		public T Add(T entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException("entity");
			}

			Entities.Add(entity);
			_context.SaveChanges();
			return entity;
		}

		public T Update(T entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException("entity");
			}

			_context.SaveChanges();
			return entity;
		}

		public void Delete(T entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException("entity");
			}

			Entities.Remove(entity);
			_context.SaveChanges();
		}

		private string GetEntityName()
		{
			return string.Format("{0}.{1}", _context.ObjectContext.DefaultContainerName, typeof(T).Name);
		}
	}
}
