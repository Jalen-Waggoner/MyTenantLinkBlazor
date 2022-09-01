using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyTenantLink.Models;
using MyTenantLink.Services.Repo.Interfaces;

namespace MyTenantLink.Pages.Customers
{
    public class EditModel : PageModel
    {
        private readonly IRepo _repo;

        public EditModel(IRepo repo)
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
            Customer = customer;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _repo.Customer.Update(Customer);

            try
            {
                await _repo.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                
                throw;
                
            }

            return RedirectToPage("/Customers/Details", new {Id = Customer.Id } );
        }

        
    }
}
