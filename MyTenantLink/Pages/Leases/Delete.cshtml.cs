using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyTenantLink.Models;
using MyTenantLink.Services.Repo.Interfaces;

namespace MyTenantLink.Pages.Leases
{
    public class DeleteModel : PageModel
    {
        private readonly IRepo _repo;

        public DeleteModel(IRepo repo)
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

            var lease = await _repo.Lease.GetByIdWithCustomerTenantAndUnitAsync(id);

            if (lease == null)
            {
                return NotFound();
            }
            else 
            {
                Lease = lease;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _repo.Lease == null)
            {
                return NotFound();
            }
            var lease = await _repo.Lease.GetByIdAsync(id);

            if (lease != null)
            {
                Lease = lease;
                _repo.Lease.Delete(Lease);
                await _repo.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
