using System.Collections.Generic;
using RentApplication.DAL.Models;

namespace RentApplication.BLL.Interfaces
{
    public interface IPropertyListService
    {
        IEnumerable<Property> GetProperties(string request, IDictionary<string, string> filter);
    }
}