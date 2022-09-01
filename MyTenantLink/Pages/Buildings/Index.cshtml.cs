using Microsoft.AspNetCore.Mvc.RazorPages;
using MyTenantLink.Models;
using MyTenantLink.Services.Repo.Interfaces;

namespace MyTenantLink.Pages.Buildings
{
    public class IndexModel : PageModel
    {
        private readonly IRepo _repo;

        public IndexModel(IRepo repo)
        {
            _repo = repo;
        }

        public IList<Building> Building { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_repo.Building != null)
            {
                Building = await _repo.Building.GetAllWithCustomersAsync();
            }
        }
    }
}
