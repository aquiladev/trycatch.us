using trycatch.Domain;

namespace trycatch.Services.Interfaces
{
	public interface ICustomerService
	{
		Customer Get(int id);
		void Update(Customer customer);
		Customer InsertGuest();
	}
}
