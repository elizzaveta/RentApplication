using System;
using System.Collections.Generic;

namespace RentApplication.PL.Builders
{
    public interface IBuilder
    {
        public Object Build();
        public IBuilder WithId(int id);

        public IBuilder WithClient(Object client);

        public IBuilder WithProperty(Object property);

        public IBuilder WithRealtor(Object realtor);

        public IBuilder WithTenant(Object tenant);

        public IBuilder WithIsActive(int flag);
        public IBuilder WithFirstName(string fName);
        public IBuilder WithLastName(string lName);
        public IBuilder WithContactPhone(string phoneNum);
        public IBuilder WithEmail(string email);

        public IBuilder WithStartWorkDate(string startWorkDay);

        public IBuilder WithType(string type);

        public IBuilder WithArea(double area);

        public IBuilder WithNumOfRooms(int numOfRooms);
        public IBuilder WithBuildingYear(int buildingYear);

        public IBuilder WithAddress(string address);

        public IBuilder WithWallsMaterial(string wallsMaterial);

        public IBuilder WithMinCost(string minCost);

        public IBuilder WithProperties(IEnumerable<Object> properties);
    }
}