using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyTenantLink.Models;
using MyTenantLink.Services.Repo.Interfaces;

namespace MyTenantLink.Pages.Customers
{
    public class DeleteModel : PageModel
    {
        private readonly IRepo _repo;

        public DeleteModel(IRepo repo)
        {
            _repo = repo;
        }

        [BindProperty]
      public Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _repo.Customer == null)
            {
                return NotFound();
            }

            var customer = await _repo.Customer.GetByIdAsync(id);

            if (customer == null)
            {
                return NotFound();
            }
            else 
            {
                Customer = customer;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _repo.Customer == null)
            {
                return NotFound();
            }
            var customer = await _repo.Customer.GetByIdAsync(id);

            if (customer != null)
            {
                Customer = customer;
                _repo.Customer.Delete(Customer);
                //await _repo.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
