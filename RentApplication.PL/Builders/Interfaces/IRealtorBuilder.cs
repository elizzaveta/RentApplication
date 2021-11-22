using RentApplication.DAL.Models;

namespace RentApplication.PL.Builders.Interfaces
{
    public interface IRealtorBuilder
    {
        public Realtor Build();

        public IRealtorBuilder WithId(int id);

        public IRealtorBuilder WithFirstName(string fName);

        public IRealtorBuilder WithLastName(string lName);

        public IRealtorBuilder WithContactPhone(string phoneNum);

        public IRealtorBuilder WithEmail(string email);

        public IRealtorBuilder WithStartWorkDate(string startWorkDay);
    }
}