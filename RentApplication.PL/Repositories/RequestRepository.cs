using System.Collections.Generic;
using System.Linq;
using RentApplication.DAL;
using RentApplication.DAL.Models;
using RentApplication.PL.Builders;
using RentApplication.PL.Builders.Interfaces;
using RentApplication.PL.Interfaces;
using Request = RentApplication.DAL.Models.Request;

namespace RentApplication.PL.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly RentApplicationDbContext _db;
        private readonly IRequestBuilder _requestBuilder;

        public RequestRepository(RentApplicationDbContext context, IRequestBuilder requestBuilder)
        {
            _db = context;
            _requestBuilder = requestBuilder;
        }

        public IEnumerable<Request> GetRequests()
        {
            return _db.Requests; // ?????????????

            var requests = _db.Requests;
            var requestsToGet = new List<Request>();
            foreach (var request in requests)
            {
                requestsToGet.Add(
                    _requestBuilder
                        .WithId(request.Id)
                        .WithClient(request.Client)
                        .WithProperty(request.Property)
                        .WithRealtor(request.Realtor)
                        .WithTenant(request.Tenant)
                        .WithIsActive(request.IsActive)
                        .Build());
            }

            return requestsToGet;
        }

        public Request GetRequest(int id)
        {
            var request = _db.Requests.FirstOrDefault(r => r.Id == id);
            if (request == null) return null;
            return _requestBuilder
                .WithId(request.Id)
                .WithClient(request.Client)
                .WithProperty(request.Property)
                .WithRealtor(request.Realtor)
                .WithTenant(request.Tenant)
                .WithIsActive(request.IsActive)
                .Build();
        }

        public void Create(Request request)
        {
            var requestToAdd = _requestBuilder
                .WithId(request.Id)
                .WithClient(request.Client)
                .WithProperty(request.Property)
                .WithRealtor(request.Realtor)
                .WithTenant(request.Tenant)
                .WithIsActive(request.IsActive)
                .Build();
            _db.Requests.Add(requestToAdd);
            _db.SaveChanges();
        }

        public void CreateRange(IEnumerable<Request> requests)
        {
            var requestsToAdd = new List<Request>();
            foreach (var request in requests)
            {
                requestsToAdd.Add(
                    _requestBuilder
                        .WithId(request.Id)
                        .WithClient(request.Client)
                        .WithProperty(request.Property)
                        .WithRealtor(request.Realtor)
                        .WithTenant(request.Tenant)
                        .WithIsActive(request.IsActive)
                        .Build());
            }

            _db.Requests.AddRange(requestsToAdd);
            _db.SaveChanges();
        }

        public void Update(Request request)
        {
            var requestToUpdate = _db.Requests.FirstOrDefault(r => r.Id == request.Id);
            if (requestToUpdate != null)
            {
                requestToUpdate.IsActive = request.IsActive;
                _db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var request = _db.Requests.FirstOrDefault(r => r.Id == id);
            if (request != null)
            {
                _db.Requests.Remove(request);
            }

            _db.SaveChanges();
        }
    }
}