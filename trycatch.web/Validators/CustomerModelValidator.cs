using FluentValidation;
using trycatch.web.Models;

namespace trycatch.web.Validators
{
	public class CustomerModelValidator : AbstractValidator<CustomerModel>
	{
		public CustomerModelValidator()
		{
			RuleFor(x => x.Email).NotEmpty().WithMessage("Email field is required");
			RuleFor(x => x.Email).EmailAddress().WithMessage("Wrong email format");

			RuleFor(x => x.FirstName).NotEmpty().WithMessage("FirstName field is required");
			RuleFor(x => x.LastName).NotEmpty().WithMessage("LastName field is required");
			RuleFor(x => x.Address).NotEmpty().WithMessage("Address field is required");
			RuleFor(x => x.HousNumber).NotEmpty().WithMessage("HousNumber field is required");
			RuleFor(x => x.ZipCode).NotEmpty().WithMessage("ZipCode field is required");
			RuleFor(x => x.City).NotEmpty().WithMessage("City field is required");
		}
	}
}