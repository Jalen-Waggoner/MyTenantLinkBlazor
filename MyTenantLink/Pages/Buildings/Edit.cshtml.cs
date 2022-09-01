using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyTenantLink.Models;
using MyTenantLink.Models.Enums;
using MyTenantLink.Services.Repo.Interfaces;

namespace MyTenantLink.Pages.Buildings
{
    public class EditModel : PageModel
    {
        private readonly IRepo _repo;

        public EditModel(IRepo repo)
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

            var building =  await _repo.Building.GetByIdAsync(id);
            if (building == null)
            {
                return NotFound();
            }
            Building = building;
           ViewData["CustomerId"] = new SelectList(await _repo.Customer.GetAllAsync(), "Id", "Name");
           ViewData["States"] = new SelectList(Enum.GetNames(typeof(State)), "IN");
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

            _repo.Building.Update(Building);

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
