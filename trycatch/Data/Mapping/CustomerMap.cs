using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using trycatch.Domain;

namespace trycatch.Data.Mapping
{
	internal class CustomerMap : EntityTypeConfiguration<Customer>
	{
		public CustomerMap()
		{
			HasKey(r => r.Id);
			Property(r => r.Id)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			ToTable("Customer");
		}
	}
}
