using Microsoft.AspNetCore.Mvc.RazorPages;
using MyTenantLink.Models;
using MyTenantLink.Services.Repo.Interfaces;

namespace MyTenantLink.Pages.Leases
{
    public class IndexModel : PageModel
    {
        private readonly IRepo _repo;

        public IndexModel(IRepo repo)
        {
            _repo = repo;
        }

        public IList<Lease> Lease { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_repo.Lease != null)
            {
                Lease = (IList<Lease>)await _repo.Lease.GetAllWithCustomersTenantsAndUnitsAsync();
            }
        }
    }
}
