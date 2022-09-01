using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyTenantLink.Models;
using MyTenantLink.Services.Repo.Interfaces;

namespace MyTenantLink.Pages.Units
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
        ViewData["BuildingId"] = new SelectList(await _repo.Building.GetAllAsync(), "Id", "BuildingCode");
        ViewData["CustomerId"] = new SelectList(await _repo.Customer.GetAllAsync(), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Unit Unit { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _repo.Unit == null || Unit == null)
            {
                return Page();
            }

            _repo.Unit.AddAsync(Unit);
            await _repo.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
