using System.Collections.Generic;

namespace RentApplication.BLL.Interfaces
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);
        object Handle(string request, object filter);
    }
}