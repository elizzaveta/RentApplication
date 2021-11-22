using RentApplication.DAL.Models;
using RentApplication.PL.Builders.Interfaces;

namespace RentApplication.PL.Builders
{
    public class PropertyBuilder : IPropertyBuilder
    {
        private readonly Property _property = new Property();

        public Property Build() => _property;

        public IPropertyBuilder WithId(int id)
        {
            _property.Id = id;
            return this;
        }

        public IPropertyBuilder WithClient(Client client)
        {
            _property.Client = client;
            return this;
        }


        public IPropertyBuilder WithType(string type)
        {
            _property.Type = type;
            return this;
        }

        public IPropertyBuilder WithArea(double area)
        {
            _property.Area = area;
            return this;
        }

        public IPropertyBuilder WithNumOfRooms(int numOfRooms)
        {
            _property.NumOfRooms = numOfRooms;
            return this;
        }

        public IPropertyBuilder WithFloorNum(int floorNum)
        {
            _property.FloorNum = floorNum;
            return this;
        }

        public IPropertyBuilder WithBuildingYear(int buildingYear)
        {
            _property.BuildingYear = buildingYear;
            return this;
        }

        public IPropertyBuilder WithAddress(string address)
        {
            _property.Address = address;
            return this;
        }

        public IPropertyBuilder WithWallsMaterial(string wallsMaterial)
        {
            _property.WallsMaterial = wallsMaterial;
            return this;
        }

        public IPropertyBuilder WithMinCost(string minCost)
        {
            _property.MinCost = minCost;
            return this;
        }
    }
}