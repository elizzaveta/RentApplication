using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RentApplication.DAL;
using RentApplication.DAL.Models;
using RentApplication.PL.Interfaces;
using RentApplication.PL.Builders;
using RentApplication.PL.Builders.Interfaces;
using Property = RentApplication.DAL.Models.Property;

namespace RentApplication.PL.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly RentApplicationDbContext _db;
        private readonly IPropertyBuilder _propertyBuilder;

        public PropertyRepository(RentApplicationDbContext context, IPropertyBuilder propertyBuilder)
        {
            _db = context;
            _propertyBuilder = propertyBuilder;
        }

        public IEnumerable<Property> GetProperties()
        {
            return _db.Properties; // ?????????????

            var properties = _db.Properties;
            var propertiesToGet = new List<Property>();
            foreach (var property in properties)
            {
                propertiesToGet.Add(
                    _propertyBuilder
                        .WithId(property.Id)
                        .WithClient(property.Client)
                        .WithType(property.Type)
                        .WithArea(property.Area)
                        .WithNumOfRooms(property.NumOfRooms)
                        .WithFloorNum(property.FloorNum)
                        .WithBuildingYear(property.BuildingYear)
                        .WithAddress(property.Address)
                        .WithWallsMaterial(property.WallsMaterial)
                        .WithMinCost(property.MinCost)
                        .Build());
            }

            return propertiesToGet;
        }

        public Property GetProperty(int id)
        {
            // _db.Properties.FirstOrDefault(p => p.Id == id);

            var property = _db.Properties.FirstOrDefault(p => p.Id == id);
            if (property == null) return null;
            return _propertyBuilder
                .WithId(property.Id)
                .WithClient(property.Client)
                .WithType(property.Type)
                .WithArea(property.Area)
                .WithNumOfRooms(property.NumOfRooms)
                .WithFloorNum(property.FloorNum)
                .WithBuildingYear(property.BuildingYear)
                .WithAddress(property.Address)
                .WithWallsMaterial(property.WallsMaterial)
                .WithMinCost(property.MinCost)
                .Build();
        }

        public void Create(object property, Client client)
        {
            var propertyToPost = JObject.Parse(JsonConvert.SerializeObject(property));

            var type = (string) propertyToPost["type"];
            var area = (double) propertyToPost["area"];
            
            var propertyToAdd = _propertyBuilder
                .WithClient(client)
                .WithType((string)propertyToPost["type"])
                .WithArea((double)propertyToPost["area"])
                .WithNumOfRooms((int)propertyToPost["numOfRooms"])
                .WithFloorNum((int)propertyToPost["floorNum"])
                .WithBuildingYear((int)propertyToPost["buildingYear"])
                .WithAddress((string)propertyToPost["address"])
                .WithWallsMaterial((string)propertyToPost["wallsMaterial"])
                .WithMinCost((string)propertyToPost["minCost"])
                .Build();
            _db.Properties.Add(propertyToAdd);
            _db.SaveChanges();
        }

        public void CreateRange(IEnumerable<Property> properties)
        {
            var propertiesToAdd = new List<Property>();
            foreach (var property in properties)
            {
                propertiesToAdd.Add(
                    _propertyBuilder
                        .WithId(property.Id)
                        .WithClient(property.Client)
                        .WithType(property.Type)
                        .WithArea(property.Area)
                        .WithNumOfRooms(property.NumOfRooms)
                        .WithFloorNum(property.FloorNum)
                        .WithBuildingYear(property.BuildingYear)
                        .WithAddress(property.Address)
                        .WithWallsMaterial(property.WallsMaterial)
                        .WithMinCost(property.MinCost)
                        .Build());
            }

            _db.Properties.AddRange(propertiesToAdd);
            _db.SaveChanges();
        }

        public void Update(Property property)
        {
            var PropertyToUpdate = _db.Properties.FirstOrDefault(p => p.Id == property.Id);
            if (PropertyToUpdate != null)
            {
                PropertyToUpdate.MinCost = property.MinCost;
                _db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var Property = _db.Properties.FirstOrDefault(p => p.Id == id);
            if (Property != null)
            {
                _db.Properties.Remove(Property);
            }

            _db.SaveChanges();
        }
    }
}