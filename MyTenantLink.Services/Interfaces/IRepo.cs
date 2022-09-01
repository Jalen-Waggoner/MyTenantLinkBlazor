using System;
using System.Threading.Tasks;

namespace MyTenantLink.Services.Repo.Interfaces {
  public interface IRepo : IDisposable {

    BuildingRepo Building { get; }
    CustomerRepo Customer { get; }
    LeaseRepo Lease { get; }
    TenantRepo Tenant { get; }
    UnitRepo Unit { get; }
    TransactionRepo Transaction { get; }


        Task<int> SaveChangesAsync();
  }
}
