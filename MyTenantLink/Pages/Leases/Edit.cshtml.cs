using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyTenantLink.Models;
using MyTenantLink.Services.Repo.Interfaces;

namespace MyTenantLink.Pages.Leases
{
    public class EditModel : PageModel
    {
        private readonly IRepo _repo;

        public EditModel(IRepo repo)
        {
            _repo = repo;
        }

        [BindProperty]
        public Lease Lease { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _repo.Lease == null)
            {
                return NotFound();
            }

            var lease =  await _repo.Lease.GetByIdWithCustomerTenantAndUnitAsync(id);
            if (lease == null)
            {
                return NotFound();
            }
            Lease = lease;
           ViewData["CustomerId"] = new SelectList(await _repo.Customer.GetAllAsync(), "Id", "Name");
           ViewData["TenantId"] = new SelectList(await _repo.Tenant.GetAllAsync(), "Id", "FirstName");
           ViewData["UnitId"] = new SelectList(await _repo.Unit.GetAllAsync(), "Id", "Id");
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

            _repo.Lease.Update(Lease);

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
