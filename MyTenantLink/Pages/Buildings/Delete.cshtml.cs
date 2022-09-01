using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyTenantLink.Models;
using MyTenantLink.Services.Repo.Interfaces;

namespace MyTenantLink.Pages.Buildings
{
    public class DeleteModel : PageModel
    {
        private readonly IRepo _repo;

        public DeleteModel(IRepo repo)
        {
            _repo = repo;
        }

        [BindProperty]
      public Building Building { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _repo.Building == null)
            {
                return NotFound();
            }

            var building = await _repo.Building.GetByIdWithCustomersAsync(id);

            if (building == null)
            {
                return NotFound();
            }
            else 
            {
                Building = building;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _repo.Building == null)
            {
                return NotFound();
            }
            var building = await _repo.Building.GetByIdAsync(id);

            if (building != null)
            {
                Building = building;
                _repo.Building.Delete(Building);
                await _repo.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
