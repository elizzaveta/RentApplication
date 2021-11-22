using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using RentApplication.BLL.Interfaces;
using RentApplication.DAL.Models;
using RentApplication.PL.Interfaces;
using RentApplication.PL.Repositories;

namespace RentApplication.BLL.Services
{
    public class PropertyListService : IPropertyListService
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IPropertyRepository _propertyRepository;

        public PropertyListService(IRequestRepository requestRepository, IPropertyRepository propertyRepository)
        {
            _requestRepository = requestRepository;
            _propertyRepository = propertyRepository;
        }

        public IEnumerable<Property> GetProperties(string request, IDictionary<string, string> filter)
        {
            var properties = _propertyRepository.GetProperties().ToArray();
            var requests = _requestRepository.GetRequests().ToArray();
            int i = 1;
            foreach (var req in requests)
            {
                req.Property = properties.FirstOrDefault(p => p.Id == i);
                i++;
            }

            var propertyWithRequest = properties.Join(requests,
                p => p.Id,
                r => r.Property.Id,
                (p, r) => new {Property = p, isAvtive = r.IsActive});


            var filter1 = propertyWithRequest.Where(p =>
                {
                    foreach (var filterParam in filter)
                    {
                        if (filterParam.Key == "isActive")
                        {
                            return p.isAvtive.ToString() == filterParam.Value;
                        }
                        else
                        {
                            switch (filterParam.Key)
                            {
                                case "type": return p.Property.Type == filterParam.Value;
                                case "numOfRooms": return p.Property.NumOfRooms.ToString() == filterParam.Value;
                                default: return true;
                            }
                        }
                    }

                    return false;
                }
            );
            return filter1.Select(p => p.Property);
            ;

            // return propertyWithRequest.Where(p =>
            //     p.Property.Type == filter["type"] &&
            //     p.isAvtive.ToString() == filter["isActive"] &&
            //     p.Property.NumOfRooms.ToString() == filter["numOfRooms"] &&
            //     p.Property.MinCost == filter["minCost"]
            // ).Select(p => p.Property);
        }
    }
}