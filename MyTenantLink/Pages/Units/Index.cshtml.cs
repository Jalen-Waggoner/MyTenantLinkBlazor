using Microsoft.AspNetCore.Mvc.RazorPages;
using MyTenantLink.Models;
using MyTenantLink.Services.Repo.Interfaces;

namespace MyTenantLink.Pages.Units
{
    public class IndexModel : PageModel
    {
        private readonly IRepo _repo;

        public IndexModel(IRepo repo)
        {
            _repo = repo;
        }

        public IList<Unit> Unit { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_repo.Unit != null)
            {
                Unit = await _repo.Unit.GetAllWithCustomersAsync();
            }
        }
    }
}
