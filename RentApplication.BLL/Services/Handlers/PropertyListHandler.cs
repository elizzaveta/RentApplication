using System.Collections.Generic;
using RentApplication.BLL.Interfaces;

namespace RentApplication.BLL.Services.Handlers
{
    public class PropertyListHandler : AbstractHandler
    {
        private readonly IPropertyListService _listService;

        public PropertyListHandler(IPropertyListService listService)
        {
            _listService = listService;
        }

        public override object Handle(string request, object filter = null)
        {
            return request.Contains("search") ? _listService.GetProperties(request, (IDictionary<string, string>)filter) : base.Handle(request, filter);
        }
    }
}