using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyTenantLink.Models;
using MyTenantLink.Services.Repo.Interfaces;

namespace MyTenantLink.Pages.Leases
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
        ViewData["TenantId"] = new SelectList(await _repo.Tenant.GetAllAsync(), "Id", "FirstName");
        ViewData["UnitId"] = new SelectList(await _repo.Unit.GetAllAsync(), "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Lease Lease { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _repo.Lease == null || Lease == null)
            {
                return Page();
            }

            _repo.Lease.AddAsync(Lease);
            await _repo.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
