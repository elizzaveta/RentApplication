using RentApplication.DAL.Models;

namespace RentApplication.PL.Builders.Interfaces
{
    public interface IRequestBuilder
    {
        public Request Build();

        public IRequestBuilder WithId(int id);

        public IRequestBuilder WithClient(Client client);

        public IRequestBuilder WithProperty(Property property);

        public IRequestBuilder WithRealtor(Realtor realtor);

        public IRequestBuilder WithTenant(Tenant tenant);

        public IRequestBuilder WithIsActive(int flag);
    }
}