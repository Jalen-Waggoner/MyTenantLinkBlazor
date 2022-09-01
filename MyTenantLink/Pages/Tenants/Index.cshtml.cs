using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyTenantLink.Models;
using MyTenantLink.Services.Repo.Interfaces;

namespace MyTenantLink.Pages.Tenants
{
    public class IndexModel : PageModel
    {
        private readonly IRepo _repo;

        public IndexModel(IRepo repo)
        {
            _repo = repo;
        }

        public IList<Tenant> Tenant { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_repo.Tenant != null)
            {
                Tenant = await _repo.Tenant.GetAllWithCustomersAsync();
            }
        }
    }
}
