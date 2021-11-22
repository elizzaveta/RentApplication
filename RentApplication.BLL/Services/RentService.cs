using System.Collections.Generic;
using RentApplication.BLL.Interfaces;
using RentApplication.BLL.Services.Handlers;
using RentApplication.DAL.Models;

namespace RentApplication.BLL.Services
{
    public class RentService : IRentService
    {
        private readonly IPropertyInfoService _infoService;
        private readonly IPropertyListService _listService;
        private readonly IHandler _requestHandler;


        public RentService(IPropertyInfoService infoService, IPropertyListService listService)
        {
            _infoService = infoService;
            _listService = listService;
            _requestHandler = new PropertyListHandler(_listService);
            _requestHandler.SetNext(new PriceListHandler(_infoService))
                .SetNext(new DetailsHandler(_infoService));
        }

        public object HandleRequest(string request, object filters = null)
        {
            return _requestHandler.Handle(request, filters);
        }

        public IEnumerable<Property> GetProperties(string request, IDictionary<string, string> filter)
        {
            return _listService.GetProperties(request, filter);
        }

        public IDictionary<string, string> GetPriceList(string request)
        {
            return _infoService.GetPriceList(request);
        }

        public Property GetDetails(string request)
        {
            return _infoService.GetDetails(request);
        }
    }
}