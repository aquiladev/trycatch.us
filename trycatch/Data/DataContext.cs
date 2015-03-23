using System.Data.Entity;
using trycatch.Data.Mapping;

namespace trycatch.Data
{
	internal class DataContext : DbContext, IDbContext
	{
		public DataContext() : this("DefaultConnection") { }

		internal DataContext(string connectionString)
			: base(connectionString)
		{
			Database.SetInitializer(new CreateDatabaseIfNotExists<DataContext>());
		}

		public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
		{
			return base.Set<TEntity>();
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new ArticleMap());

			base.OnModelCreating(modelBuilder);
		}
	}
}
