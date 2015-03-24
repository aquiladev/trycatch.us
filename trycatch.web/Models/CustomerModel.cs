using FluentValidation.Attributes;
using trycatch.Domain;
using trycatch.web.Validators;

namespace trycatch.web.Models
{
	[Validator(typeof(CustomerModelValidator))]
	public class CustomerModel
	{
		public int Id { get; set; }
		public PersonalTitle Title { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Address { get; set; }
		public string HousNumber { get; set; }
		public string ZipCode { get; set; }
		public string City { get; set; }
		public string Email { get; set; }
	}
}