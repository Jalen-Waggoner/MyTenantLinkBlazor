using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyTenantLink.Models;
using MyTenantLink.Models.Enums;
using MyTenantLink.Services.Repo.Interfaces;

namespace MyTenantLink.Pages.Buildings
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
        ViewData["States"] = new SelectList(Enum.GetNames(typeof(State)),"IN");
            return Page();
        }

        [BindProperty]
        public Building Building { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _repo.Building == null || Building == null)
            {
                return Page();
            }

            await _repo.Building.AddAsync(Building);
            await _repo.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
