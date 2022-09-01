using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyTenantLink.Data;
using MyTenantLink.Models;
using MyTenantLink.Services.Repo.Interfaces;

namespace MyTenantLink.Pages.Buildings
{
    public class DetailsModel : PageModel
    {
        private readonly IRepo _repo;

        public DetailsModel(IRepo repo)
        {
            _repo = repo;
        }

        public Building Building { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _repo.Building == null)
            {
                return NotFound();
            }

            var building = await _repo.Building.GetByIdWithCustomersAndUnitsAsync(id);
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
    }
}
