using System.Collections.Generic;
using System.Linq;
using RentApplication.DAL;
using RentApplication.DAL.Models;
using RentApplication.PL.Builders;
using RentApplication.PL.Builders.Interfaces;
using RentApplication.PL.Interfaces;

namespace RentApplication.PL.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly RentApplicationDbContext _db;
        private readonly IClientBuilder _clientBuilder;

        public ClientRepository(RentApplicationDbContext context, IClientBuilder clientBuilder)
        {
            _db = context;
            _clientBuilder = clientBuilder;
        }

        public IEnumerable<Client> GetClients()
        {
            var clients = _db.Clients;
            var clientsToGet = new List<Client>();
            foreach (var client in clients)
            {
                clientsToGet.Add(
                    _clientBuilder
                        .WithId(client.Id)
                        .WithFirstName(client.FirstName)
                        .WithLastName(client.LastName)
                        .WithContactPhone(client.ContactPhone)
                        .WithProperties(client.Properties)
                        .Build());
            }

            return clientsToGet;
        }

        public Client GetClient(int id)
        {
            var client = _db.Clients.FirstOrDefault(c => c.Id == id);
            if (client == null) return null;
            return _clientBuilder
                .WithId(client.Id)
                .WithFirstName(client.FirstName)
                .WithLastName(client.LastName)
                .WithContactPhone(client.ContactPhone)
                .WithProperties(client.Properties)
                .Build();
        }

        public void Create(Client client)
        {
            var clientToAdd = _clientBuilder
                .WithId(client.Id)
                .WithFirstName(client.FirstName)
                .WithLastName(client.LastName)
                .WithContactPhone(client.ContactPhone)
                .WithProperties(client.Properties)
                .Build();
            _db.Clients.Add(clientToAdd);
            _db.SaveChanges();
        }

        public void CreateRange(IEnumerable<Client> clients)
        {
            var clientsToAdd = new List<Client>();
            foreach (var client in clients)
            {
                clientsToAdd.Add(
                    _clientBuilder
                        .WithId(client.Id)
                        .WithFirstName(client.FirstName)
                        .WithLastName(client.LastName)
                        .WithContactPhone(client.ContactPhone)
                        .WithProperties(client.Properties)
                        .Build());
            }

            _db.Clients.AddRange(clientsToAdd);
            _db.SaveChanges();
        }

        public void Update(Client client)
        {
            var clientToUpdate = _db.Clients.FirstOrDefault(c => c.Id == client.Id);
            if (clientToUpdate != null)
            {
                clientToUpdate.ContactPhone = client.ContactPhone;
                _db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var client = _db.Clients.FirstOrDefault(c => c.Id == id);
            if (client != null)
            {
                _db.Clients.Remove(client);
            }

            _db.SaveChanges();
        }
    }
}