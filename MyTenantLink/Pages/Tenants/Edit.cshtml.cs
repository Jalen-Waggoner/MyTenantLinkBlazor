using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyTenantLink.Data;
using MyTenantLink.Models;
using MyTenantLink.Services.Repo.Interfaces;

namespace MyTenantLink.Pages.Tenants
{
    public class EditModel : PageModel
    {
        private readonly IRepo _repo;

        public EditModel(IRepo repo)
        {
            _repo = repo;
        }

        [BindProperty]
        public Tenant Tenant { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _repo.Tenant == null)
            {
                return NotFound();
            }

            var tenant =  await _repo.Tenant.GetByIdAsync(id);
            if (tenant == null)
            {
                return NotFound();
            }
            Tenant = tenant;
           ViewData["CustomerId"] = new SelectList(await _repo.Customer.GetAllAsync(), "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _repo.Tenant.Update(Tenant);

            try
            {
                await _repo.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                
                throw;
                
            }

            return RedirectToPage("./Index");
        }

        
    }
}
