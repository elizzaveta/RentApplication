using System.Collections.Generic;
using RentApplication.DAL.Models;

namespace RentApplication.PL.Interfaces
{
    public interface IRequestRepository
    {
        IEnumerable<Request> GetRequests();
        Request GetRequest(int id);
        void Create(Request request);
        void CreateRange(IEnumerable<Request> request);
        void Update(Request request);
        void Delete(int id);
    }
}