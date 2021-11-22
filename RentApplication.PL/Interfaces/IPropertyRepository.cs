using System.Collections.Generic;
using RentApplication.DAL.Models;

namespace RentApplication.PL.Interfaces
{
    public interface IPropertyRepository
    {
        IEnumerable<Property> GetProperties();
        Property GetProperty(int id);
        void Create(object property, Client client);
        void CreateRange(IEnumerable<Property> property);
        void Update(Property property);
        void Delete(int id);
    }
}