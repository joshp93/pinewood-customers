using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PinewoodCustomers.Models;

namespace PinewoodCustomers.Pages
{
	public class CustomersModel : PageModel
	{
		private readonly CustomerDbContext _context;

		[BindProperty]
		public Customer NewCustomer { get; set; }

		public List<Customer> Customers { get; set; } = new List<Customer>();

		public CustomersModel(CustomerDbContext context)
		{
			_context = context;
		}

		public void OnGet()
		{
			ViewData["Title"] = "Customers";
			Customers = _context.Customers.ToList();
		}

		public IActionResult OnPost()
		{
			NewCustomer.Id = Guid.NewGuid();
			NewCustomer.CreationDate = DateTime.Now;
			_context.Add(NewCustomer);
			_context.SaveChanges();

			return RedirectToPage();
		}

		public IActionResult OnPostEdit(Guid id)
		{
			return RedirectToPage("/Customer", new { id });
		}

		public RedirectToPageResult OnPostRemove(Guid id)
		{
			Customer customer = _context.Customers.Find(id)!;
			_context.Customers.Remove(customer);
			_context.SaveChanges();

			return RedirectToPage();
		}
	}
}
