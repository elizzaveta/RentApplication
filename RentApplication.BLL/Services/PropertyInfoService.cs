using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RentApplication.BLL.Interfaces;
using RentApplication.DAL.Models;
using RentApplication.PL.Interfaces;
using RentApplication.PL.Repositories;

namespace RentApplication.BLL.Services
{
    public class PropertyInfoService : IPropertyInfoService
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IClientRepository _clientRepository;

        public PropertyInfoService(IPropertyRepository propertyRepository, IClientRepository clientRepository)
        {
            _propertyRepository = propertyRepository;
            _clientRepository = clientRepository;
        }

        public IDictionary<string, string> GetPriceList(string request)
        {
            var priceList = new Dictionary<string, string>();
            var properties = _propertyRepository.GetProperties();
            var i = 0;
            foreach (var property in properties)
            {
                priceList.Add(i.ToString(), property.MinCost + ' ' + property.Address);
                i++;
            }

            return priceList;
        }

        public Property GetDetails(string request)
        {
            var id = Convert.ToInt32(request.Substring(request.IndexOf('/') + 1));
            var property = _propertyRepository.GetProperty(id);
            property.Client = _clientRepository.GetClient(id);
            return property;
        }

        public void PostDetails(object property)
        {
            var propertyToPost = JObject.Parse(JsonConvert.SerializeObject(property));
            var client = _clientRepository.GetClient(Convert.ToInt32(propertyToPost["clientId"]));
            _propertyRepository.Create(property, client);
        }
    }
}