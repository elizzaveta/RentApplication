using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RentApplication.BLL.Interfaces;
using RentApplication.BLL.Services;
using RentApplication.DAL.Models;

namespace RentApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RequestController : ControllerBase
    {
        private readonly ILogger<RequestController> _logger;
        private readonly IRentService _rentService;

        public RequestController(ILogger<RequestController> logger, IRentService rentService)
        {
            _logger = logger;
            _rentService = rentService;
        }


        [HttpGet("search")]
        public IEnumerable<Property> GetProperties([FromQuery] IDictionary<string, string> filters)
        {
            // var filters = new Dictionary<string, string>
            // {
            //     {"type", type},
            //     {"isActive", isActive},
            //     {"numOfRooms", numOfRooms},
            //     {"minCost", minCost}
            // };

            return (IEnumerable<Property>) _rentService.HandleRequest("search", filters);
        }

        [HttpGet("price-list")]
        public IDictionary<string, string> GetPrice()
        {
            return (IDictionary<string, string>) _rentService.HandleRequest("price-list");
        }

        [HttpGet("details/{id}")]
        public Property GetPropertyDetails(int id)
        {
            return (Property) _rentService.HandleRequest($"details/{id}");
        }
        
        
        [HttpPost("property")]
        public string PostData([FromBody]object property)
        {
            var propertyToPost = JObject.Parse(JsonConvert.SerializeObject(property));
            var attribute = propertyToPost["type"];
            _rentService.HandleRequest("property", property);
            return "Property is added to db. type: " + attribute;
        }
        
        

        // [HttpGet("search/type={type}&isActive={isActive}&numOfRooms={numOfRooms}&minCost={minCost}")]
        // public IEnumerable<Property> GetProperties(string type, string isActive, string numOfRooms, string minCost)
        // {
        //     var filters = new Dictionary<string, string>
        //     {
        //         {"type", type},
        //         {"isActive", isActive},
        //         {"numOfRooms", numOfRooms},
        //         {"minCost", minCost}
        //     };
        //
        //     return (IEnumerable<Property>) _rentService.HandleRequest("search", filters);
        // }
        //
        // [HttpGet("price-list")]
        // public IDictionary<string, string> GetPrice()
        // {
        //     return (IDictionary<string, string>) _rentService.HandleRequest("price-list");
        // }
        //
        // [HttpGet("details/{id}")]
        // public Property GetPropertyDetails(int id)
        // {
        //     return (Property) _rentService.HandleRequest($"details/{id}");
        // }
    }
}