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

namespace MyTenantLink.Pages.Tenants
{
    public class CreateModel : PageModel
    {
        private readonly IRepo _repo;

        public CreateModel(IRepo repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> OnGetAsync()
        {
        ViewData["CustomerId"] = new SelectList(await _repo.Customer.GetAllAsync(), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Tenant Tenant { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _repo.Tenant == null || Tenant == null)
            {
                return Page();
            }

            _repo.Tenant.AddAsync(Tenant);
            await _repo.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
