using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyTenantLink.Models;
using MyTenantLink.Services.Repo.Interfaces;

namespace MyTenantLink.Pages.Units
{
    public class EditModel : PageModel
    {
        private readonly IRepo _repo;

        public EditModel(IRepo repo)
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

            var unit =  await _repo.Unit.GetByIdAsync(id);
            if (unit == null)
            {
                return NotFound();
            }
            Unit = unit;
           ViewData["BuildingId"] = new SelectList(await _repo.Building.GetAllAsync(), "Id", "BuildingCode");
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

            _repo.Unit.Update(Unit);

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
