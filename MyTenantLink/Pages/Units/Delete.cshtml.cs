using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyTenantLink.Models;
using MyTenantLink.Services.Repo.Interfaces;

namespace MyTenantLink.Pages.Units
{
    public class DeleteModel : PageModel
    {
        private readonly IRepo _repo;

        public DeleteModel(IRepo repo)
        {
            _repo = repo;
        }

        [BindProperty]
      public Unit Unit { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _repo.Unit == null)
            {
                return NotFound();
            }

            var unit = await _repo.Unit.GetByIdWithBuildingsAsync(id);

            if (unit == null)
            {
                return NotFound();
            }
            else 
            {
                Unit = unit;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _repo.Unit == null)
            {
                return NotFound();
            }
            var unit = await _repo.Unit.GetByIdAsync(id);

            if (unit != null)
            {
                Unit = unit;
                _repo.Unit.Delete(Unit);
                await _repo.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
