using System.Collections.Generic;
using RentApplication.DAL.Models;

namespace RentApplication.PL.Builders.Interfaces
{
    public interface IClientBuilder
    {
        public Client Build();

        public IClientBuilder WithId(int id);

        public IClientBuilder WithFirstName(string fName);

        public IClientBuilder WithLastName(string lName);

        public IClientBuilder WithContactPhone(string phoneNum);

        public IClientBuilder WithProperties(IEnumerable<Property> properties);
    }
}