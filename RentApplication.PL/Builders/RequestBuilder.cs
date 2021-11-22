using System.Collections.Generic;
using RentApplication.DAL.Models;
using RentApplication.PL.Builders.Interfaces;

namespace RentApplication.PL.Builders
{
    public class RequestBuilder : IRequestBuilder
    {
        private readonly Request _request = new Request();

        public Request Build() => _request;

        public IRequestBuilder WithId(int id)
        {
            _request.Id = id;
            return this;
        }

        public IRequestBuilder WithClient(Client client)
        {
            _request.Client = client;
            return this;
        }

        public IRequestBuilder WithProperty(Property property)
        {
            _request.Property = property;
            return this;
        }

        public IRequestBuilder WithRealtor(Realtor realtor)
        {
            _request.Realtor = realtor;
            return this;
        }

        public IRequestBuilder WithTenant(Tenant tenant)
        {
            _request.Tenant = tenant;
            return this;
        }

        public IRequestBuilder WithIsActive(int flag)
        {
            _request.IsActive = flag;
            return this;
        }
    }
}