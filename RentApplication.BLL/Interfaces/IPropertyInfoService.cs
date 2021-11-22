using System.Collections.Generic;
using RentApplication.DAL.Models;

namespace RentApplication.BLL.Interfaces
{
    public interface IPropertyInfoService
    {
        IDictionary<string, string> GetPriceList(string request);

        Property GetDetails(string request);
        public void PostDetails(object property);
    }
}