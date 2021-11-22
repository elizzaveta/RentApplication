using RentApplication.DAL.Models;

namespace RentApplication.PL.Builders.Interfaces
{
    public interface ITenantBuilder
    {
        public Tenant Build();

        public ITenantBuilder WithId(int id);

        public ITenantBuilder WithFirstName(string fName);

        public ITenantBuilder WithLastName(string lName);

        public ITenantBuilder WithContactPhone(string phoneNum);
    }
}