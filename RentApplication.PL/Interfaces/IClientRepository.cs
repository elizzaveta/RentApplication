using System.Collections.Generic;
using RentApplication.DAL.Models;

namespace RentApplication.PL.Interfaces
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetClients();
        Client GetClient(int id);
        void Create(Client client);
        void CreateRange(IEnumerable<Client> client);
        void Update(Client client);
        void Delete(int id);
    }
}