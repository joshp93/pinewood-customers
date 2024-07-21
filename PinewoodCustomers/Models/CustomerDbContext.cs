using Microsoft.EntityFrameworkCore;

namespace PinewoodCustomers.Models
{
	public class CustomerDbContext : DbContext
	{
		IConfiguration _configuration;
		public CustomerDbContext(IConfiguration configuration)
		{
			_configuration = configuration;
		}
        public DbSet<Customer> Customers { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(_configuration["Database:Connection"]);
		}
	}
}
