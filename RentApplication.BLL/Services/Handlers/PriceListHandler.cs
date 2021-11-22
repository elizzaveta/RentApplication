using System.Collections.Generic;
using RentApplication.BLL.Interfaces;

namespace RentApplication.BLL.Services.Handlers
{
    public class PriceListHandler : AbstractHandler
    {
        private readonly IPropertyInfoService _infoService;

        public PriceListHandler(IPropertyInfoService infoService)
        {
            _infoService = infoService;
        }

        public override object Handle(string request, object filter = null)
        {
            return request.Contains("price-list") ? _infoService.GetPriceList(request) : base.Handle(request, filter);
        }
    }
}