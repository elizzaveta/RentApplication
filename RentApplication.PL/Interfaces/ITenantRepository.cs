using System.Collections.Generic;
using RentApplication.DAL.Models;

namespace RentApplication.PL.Interfaces
{
    public interface ITenantRepository
    {
        IEnumerable<Tenant> GetTenants();
        Tenant GetTenant(int id);
        void Create(Tenant tenant);
        void CreateRange(IEnumerable<Tenant> tenant);
        void Update(Tenant tenant);
        void Delete(int id);
    }
}