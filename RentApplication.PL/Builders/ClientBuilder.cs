using System.Collections.Generic;
using RentApplication.DAL.Models;
using RentApplication.PL.Builders.Interfaces;

namespace RentApplication.PL.Builders
{
    public class ClientBuilder : IClientBuilder
    {
        private readonly Client _client = new Client();

        public Client Build() => _client;

        public IClientBuilder WithId(int id)
        {
            _client.Id = id;
            return this;
        }

        public IClientBuilder WithFirstName(string fName)
        {
            _client.FirstName = fName;
            return this;
        }

        public IClientBuilder WithLastName(string lName)
        {
            _client.LastName = lName;
            return this;
        }

        public IClientBuilder WithContactPhone(string phoneNum)
        {
            _client.ContactPhone = phoneNum;
            return this;
        }

        public IClientBuilder WithProperties(IEnumerable<Property> properties)
        {
            _client.Properties = properties;
            return this;
        }
    }
}