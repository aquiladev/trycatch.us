using System.Data.Entity.ModelConfiguration;
using trycatch.Domain;

namespace trycatch.Data.Mapping
{
	internal class ArticleMap : EntityTypeConfiguration<Article>
	{
		public ArticleMap()
		{
			HasKey(r => r.Id);
			Property(r => r.Name).IsRequired().HasMaxLength(400);
			Property(r => r.Price).HasPrecision(18, 4);

			ToTable("Article");
		}
	}
}
