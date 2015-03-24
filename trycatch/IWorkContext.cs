using trycatch.Domain;

namespace trycatch
{
	public interface IWorkContext
	{
		Customer CurrentCustomer { get; set; }
	}
}
