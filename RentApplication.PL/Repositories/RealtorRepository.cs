using System.Collections.Generic;
using System.Linq;
using RentApplication.DAL;
using RentApplication.PL.Interfaces;
using RentApplication.DAL.Models;
using RentApplication.PL.Builders;
using RentApplication.PL.Builders.Interfaces;

namespace RentApplication.PL.Repositories
{
    public class RealtorRepository : IRealtorRepository
    {
        private readonly RentApplicationDbContext _db;
        private readonly IRealtorBuilder _realtorBuilder;

        public RealtorRepository(RentApplicationDbContext context, IRealtorBuilder realtorBuilder)
        {
            _db = context.Context;
            _realtorBuilder = realtorBuilder;
        }

        public IEnumerable<Realtor> GetRealtors()
        {
            var realtors = _db.Realtors;
            var realtorsToGet = new List<Realtor>();
            foreach (var realtor in realtors)
            {
                realtorsToGet.Add(
                    _realtorBuilder
                        .WithId(realtor.Id)
                        .WithFirstName(realtor.FirstName)
                        .WithLastName(realtor.LastName)
                        .WithContactPhone(realtor.ContactPhone)
                        .WithEmail(realtor.Email)
                        .WithStartWorkDate(realtor.StartWorkDate)
                        .Build());
            }

            return realtorsToGet;
        }

        public Realtor GetRealtor(int id)
        {
            var realtor = _db.Realtors.FirstOrDefault(r => r.Id == id);
            if (realtor == null) return null;
            return _realtorBuilder
                .WithId(realtor.Id)
                .WithFirstName(realtor.FirstName)
                .WithLastName(realtor.LastName)
                .WithContactPhone(realtor.ContactPhone)
                .WithEmail(realtor.Email)
                .WithStartWorkDate(realtor.StartWorkDate)
                .Build();
        }

        public void Create(Realtor realtor)
        {
            var realtorToAdd = _realtorBuilder
                .WithId(realtor.Id)
                .WithFirstName(realtor.FirstName)
                .WithLastName(realtor.LastName)
                .WithContactPhone(realtor.ContactPhone)
                .WithEmail(realtor.Email)
                .WithStartWorkDate(realtor.StartWorkDate)
                .Build();
            _db.Realtors.Add(realtorToAdd);
            _db.SaveChanges();
        }

        public void CreateRange(IEnumerable<Realtor> realtors)
        {
            var realtorsToAdd = new List<Realtor>();
            foreach (var realtor in realtors)
            {
                realtorsToAdd.Add(
                    _realtorBuilder
                        .WithId(realtor.Id)
                        .WithFirstName(realtor.FirstName)
                        .WithLastName(realtor.LastName)
                        .WithContactPhone(realtor.ContactPhone)
                        .WithEmail(realtor.Email)
                        .WithStartWorkDate(realtor.StartWorkDate)
                        .Build());
            }

            _db.Realtors.AddRange(realtorsToAdd);
            _db.SaveChanges();
        }

        public void Update(Realtor realtor)
        {
            var realtorToUpdate = _db.Realtors.FirstOrDefault(r => r.Id == realtor.Id);
            if (realtorToUpdate != null)
            {
                realtorToUpdate.ContactPhone = realtor.ContactPhone;
                _db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var realtor = _db.Realtors.FirstOrDefault(r => r.Id == id);
            if (realtor != null)
            {
                _db.Realtors.Remove(realtor);
            }

            _db.SaveChanges();
        }
    }
}