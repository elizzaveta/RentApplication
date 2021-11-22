using System.Collections.Generic;
using RentApplication.BLL.Interfaces;

namespace RentApplication.BLL.Services.Handlers
{
    public class AbstractHandler : IHandler
    {
        private IHandler _nextHandler;

        public IHandler SetNext(IHandler handler)
        {
            _nextHandler = handler;
            return handler;
        }

        public virtual object Handle(string request, object filter = null)
        {
            return _nextHandler?.Handle(request, filter);
        }
    }
}