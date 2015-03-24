using System.Collections.Generic;

namespace trycatch.Domain
{
	public class Customer : BaseEntity
	{
		private ICollection<ShoppingCartItem> _shoppingCartItems;

		public PersonalTitle Title { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Address { get; set; }
		public string HousNumber { get; set; }
		public string ZipCode { get; set; }
		public string City { get; set; }
		public string Email { get; set; }
		public bool IsGuest { get; set; }

		public virtual ICollection<ShoppingCartItem> ShoppingCartItems
		{
			get { return _shoppingCartItems ?? (_shoppingCartItems = new List<ShoppingCartItem>()); }
			protected set { _shoppingCartItems = value; }
		}
	}
}
