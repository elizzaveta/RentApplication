using System.Runtime.CompilerServices;
using RentApplication.DAL.Models;

namespace RentApplication.PL.Builders.Interfaces
{
    public interface IPropertyBuilder
    {
        public Property Build();

        public IPropertyBuilder WithId(int id);

        public IPropertyBuilder WithClient(Client client);

        public IPropertyBuilder WithType(string type);

        public IPropertyBuilder WithArea(double area);

        public IPropertyBuilder WithNumOfRooms(int numOfRooms);

        public IPropertyBuilder WithFloorNum(int floorNum);

        public IPropertyBuilder WithBuildingYear(int buildingYear);

        public IPropertyBuilder WithAddress(string address);

        public IPropertyBuilder WithWallsMaterial(string wallsMaterial);

        public IPropertyBuilder WithMinCost(string minCost);
    }
}