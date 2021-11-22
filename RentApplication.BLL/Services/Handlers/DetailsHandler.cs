using System.Collections.Generic;
using RentApplication.BLL.Interfaces;

namespace RentApplication.BLL.Services.Handlers
{
    public class DetailsHandler : AbstractHandler
    {
        private readonly IPropertyInfoService _infoService;

        public DetailsHandler(IPropertyInfoService infoService)
        {
            _infoService = infoService;
        }

        public override object Handle(string request, object property = null)
        {

            if (request.Contains("details") || request.Contains("property"))
            {
                if (request == "property")
                {
                    _infoService.PostDetails(property);
                    return "property added to database";
                }
                else
                {
                    return _infoService.GetDetails(request);
                }
            }
            else
            {
                return base.Handle(request);
            }
            // return request.Contains("details") ? _infoService.GetDetails(request) : base.Handle(request);
        }
    }
}