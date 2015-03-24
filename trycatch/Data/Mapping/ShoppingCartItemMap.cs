using System.Data.Entity.ModelConfiguration;
using trycatch.Domain;

namespace trycatch.Data.Mapping
{
	internal class ShoppingCartItemMap : EntityTypeConfiguration<ShoppingCartItem>
	{
		public ShoppingCartItemMap()
		{
			HasKey(sci => sci.Id);

			HasRequired(sci => sci.Customer)
				.WithMany(c => c.ShoppingCartItems)
				.HasForeignKey(sci => sci.CustomerId);

			HasRequired(sci => sci.Article)
				.WithMany()
				.HasForeignKey(sci => sci.ArticleId);

			ToTable("ShoppingCartItem");
		}
	}
}
