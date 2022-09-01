using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyTenantLink.Models;
using MyTenantLink.Services.Repo.Interfaces;

namespace MyTenantLink.Pages.Customers
{
    public class DetailsModel : PageModel
    {
        private readonly IRepo _repo;

        public DetailsModel(IRepo repo)
        {
            _repo = repo;
        }


        public Customer Customer { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _repo.Customer == null)
            {
                return NotFound();
            }

            var customer = await _repo.Customer.GetByIdWithBuilingsAsync(id);
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
    }
}
