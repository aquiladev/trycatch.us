namespace trycatch.Domain
{
	public class ShoppingCartItem : BaseEntity
	{
		public int CustomerId { get; set; }
		public int ArticleId { get; set; }
		public virtual Customer Customer { get; set; }
		public virtual Article Article { get; set; }
	}
}
