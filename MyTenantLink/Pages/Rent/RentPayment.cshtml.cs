using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyTenantLink.Data;
using MyTenantLink.Models;
using MyTenantLink.Services.Repo.Interfaces;

namespace MyTenantLink.Pages.Rent
{
    public class RentPaymentModel : PageModel
    {
        private readonly IRepo _repo;

        public RentPaymentModel(IRepo repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> OnGet()
        {
        ViewData["LeaseId"] = new SelectList(await _repo.Lease.GetAllAsync(), "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Transaction Transaction { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _repo.Transaction == null || Transaction == null)
            {
                return Page();
            }

            await _repo.Transaction.AddAsync(Transaction);
            await _repo.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
