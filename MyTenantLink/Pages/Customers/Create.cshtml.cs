using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyTenantLink.Data;
using MyTenantLink.Models;
using MyTenantLink.Services.Repo.Interfaces;

namespace MyTenantLink.Pages.Customers
{
    public class CreateModel : PageModel
    {
        private readonly IRepo _repo;

        public CreateModel(IRepo repo)
        {
            _repo = repo;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;
        

        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _repo.Customer == null || Customer == null)
            {
                return Page();
            }

            await _repo.Customer.AddAsync(Customer);
            await _repo.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
