using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyTenantLink.Models;
using MyTenantLink.Services.Repo.Interfaces;

namespace MyTenantLink.Pages.Tenants
{
    public class DeleteModel : PageModel
    {
        private readonly IRepo _repo;

        public DeleteModel(IRepo repo)
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

            var tenant = await _repo.Tenant.GetByIdAsync(id);

            if (tenant == null)
            {
                return NotFound();
            }
            else 
            {
                Tenant = tenant;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _repo.Tenant == null)
            {
                return NotFound();
            }
            var tenant = await _repo.Tenant.GetByIdAsync(id);

            if (tenant != null)
            {
                Tenant = tenant;
                _repo.Tenant.Delete(Tenant);
                await _repo.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
