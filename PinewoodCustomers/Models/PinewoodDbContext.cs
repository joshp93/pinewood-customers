using Microsoft.EntityFrameworkCore;

namespace PinewoodCustomers.Models
{
	public class PinewoodDbContext : DbContext
	{
		IConfiguration _configuration;
		public PinewoodDbContext(IConfiguration configuration)
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
