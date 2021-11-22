using RentApplication.DAL.Models;
using RentApplication.PL.Builders.Interfaces;

namespace RentApplication.PL.Builders
{
    public class RealtorBuilder : IRealtorBuilder
    {
        private readonly Realtor _realtor = new Realtor();

        public Realtor Build() => _realtor;

        public IRealtorBuilder WithId(int id)
        {
            _realtor.Id = id;
            return this;
        }

        public IRealtorBuilder WithFirstName(string fName)
        {
            _realtor.FirstName = fName;
            return this;
        }

        public IRealtorBuilder WithLastName(string lName)
        {
            _realtor.LastName = lName;
            return this;
        }

        public IRealtorBuilder WithContactPhone(string phoneNum)
        {
            _realtor.ContactPhone = phoneNum;
            return this;
        }

        public IRealtorBuilder WithEmail(string email)
        {
            _realtor.Email = email;
            return this;
        }

        public IRealtorBuilder WithStartWorkDate(string startWorkDay)
        {
            _realtor.StartWorkDate = startWorkDay;
            return this;
        }
    }
}