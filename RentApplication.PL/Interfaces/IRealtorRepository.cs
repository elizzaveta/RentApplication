using System.Collections.Generic;
using RentApplication.DAL.Models;

namespace RentApplication.PL.Interfaces
{
    public interface IRealtorRepository
    {
        IEnumerable<Realtor> GetRealtors();
        Realtor GetRealtor(int id);
        void Create(Realtor realtor);
        void CreateRange(IEnumerable<Realtor> realtor);
        void Update(Realtor realtor);
        void Delete(int id);
    }
}