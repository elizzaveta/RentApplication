using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Routing.Template;
using RentApplication.DAL;
using RentApplication.DAL.Models;
using RentApplication.PL.Builders;
using RentApplication.PL.Builders.Interfaces;
using RentApplication.PL.Interfaces;

namespace RentApplication.PL.Repositories
{
    public class TenantRepository : ITenantRepository
    {
        private readonly RentApplicationDbContext _db;
        private readonly ITenantBuilder _tenantBuilder;

        public TenantRepository(RentApplicationDbContext context, ITenantBuilder tenantBuilder)
        {
            _db = context.Context;
            _tenantBuilder = tenantBuilder;
        }

        public IEnumerable<Tenant> GetTenants()
        {
            var tenants = _db.Tenants;
            var tenantsToGet = new List<Tenant>();
            foreach (var tenant in tenants)
            {
                tenantsToGet.Add(
                    _tenantBuilder
                        .WithId(tenant.Id)
                        .WithFirstName(tenant.FirstName)
                        .WithLastName(tenant.LastName)
                        .WithContactPhone(tenant.ContactPhone)
                        .Build());
            }

            return tenantsToGet;
        }

        public Tenant GetTenant(int id)
        {
            var tenant = _db.Tenants.FirstOrDefault(t => t.Id == id);
            if (tenant == null) return null;
            return _tenantBuilder
                .WithId(tenant.Id)
                .WithFirstName(tenant.FirstName)
                .WithLastName(tenant.LastName)
                .WithContactPhone(tenant.ContactPhone)
                .Build();
        }

        public void Create(Tenant tenant)
        {
            var tenantToAdd = _tenantBuilder
                .WithId(tenant.Id)
                .WithFirstName(tenant.FirstName)
                .WithLastName(tenant.LastName)
                .WithContactPhone(tenant.ContactPhone)
                .Build();
            _db.Tenants.Add(tenantToAdd);
            _db.SaveChanges();
        }

        public void CreateRange(IEnumerable<Tenant> tenants)
        {
            var tenantsToAdd = new List<Tenant>();
            foreach (var tenant in tenants)
            {
                tenantsToAdd.Add(
                    _tenantBuilder
                        .WithId(tenant.Id)
                        .WithFirstName(tenant.FirstName)
                        .WithLastName(tenant.LastName)
                        .WithContactPhone(tenant.ContactPhone)
                        .Build());
            }

            _db.Tenants.AddRange(tenantsToAdd);
            _db.SaveChanges();
        }

        public void Update(Tenant tenant)
        {
            var tenantToUpdate = _db.Tenants.FirstOrDefault(t => t.Id == tenant.Id);
            if (tenantToUpdate != null)
            {
                tenantToUpdate.ContactPhone = tenant.ContactPhone;
                _db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var tenant = _db.Tenants.FirstOrDefault(t => t.Id == id);
            if (tenant != null)
            {
                _db.Tenants.Remove(tenant);
            }

            _db.SaveChanges();
        }
    }
}