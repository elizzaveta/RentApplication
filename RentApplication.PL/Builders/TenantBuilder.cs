using RentApplication.DAL.Models;
using RentApplication.PL.Builders.Interfaces;

namespace RentApplication.PL.Builders
{
    public class TenantBuilder : ITenantBuilder
    {
        private readonly Tenant _tenant = new Tenant();

        public Tenant Build() => _tenant;

        public ITenantBuilder WithId(int id)
        {
            _tenant.Id = id;
            return this;
        }

        public ITenantBuilder WithFirstName(string fName)
        {
            _tenant.FirstName = fName;
            return this;
        }

        public ITenantBuilder WithLastName(string lName)
        {
            _tenant.LastName = lName;
            return this;
        }

        public ITenantBuilder WithContactPhone(string phoneNum)
        {
            _tenant.ContactPhone = phoneNum;
            return this;
        }
    }
}