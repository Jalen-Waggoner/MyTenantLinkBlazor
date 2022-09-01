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

namespace MyTenantLink.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly IRepo _repo;

        public IndexModel(IRepo repo)
        {
            _repo = repo;
        }

        public IList<Customer> Customer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_repo.Customer != null)
            {
                Customer = await _repo.Customer.GetAllAsync();
            }
        }
    }
}
