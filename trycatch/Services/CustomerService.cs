using trycatch.Data;
using trycatch.Domain;
using trycatch.Services.Interfaces;

namespace trycatch.Services
{
	public class CustomerService : ICustomerService
	{
		private readonly IRepository<Customer> _customerRepository;

		public CustomerService(IRepository<Customer> customerRepository)
		{
			_customerRepository = customerRepository;
		}

		public Customer Get(int id)
		{
			return _customerRepository.Find(id);
		}

		public void Update(Customer customer)
		{
			_customerRepository.Update(customer);
		}

		public Customer InsertGuest()
		{
			return _customerRepository.Add(new Customer
			{
				IsGuest = true
			});
		}
	}
}
