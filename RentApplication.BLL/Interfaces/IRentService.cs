using System.Collections.Generic;
using RentApplication.DAL.Models;

namespace RentApplication.BLL.Interfaces
{
    public interface IRentService
    {
        public object HandleRequest(string request, object filter = null);
        public IEnumerable<Property> GetProperties(string request, IDictionary<string, string> filter);
        public IDictionary<string, string> GetPriceList(string request);
        public Property GetDetails(string request);
    }
}