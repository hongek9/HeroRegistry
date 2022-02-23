using HeroRegistry.Models.LocationModels;
using HeroRegistry.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HeroRegistry.WebAPI.Controllers
{
    public class LocationController : ApiController
    {
        private LocationService CreateLocationService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var locationService = new LocationService(userId);
            return locationService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var service = CreateLocationService();
            var locations = service.GetLocations();
            return Ok(locations);
        }

        [HttpGet]
        public IHttpActionResult Get([FromUri] int id)
        {
            var service = CreateLocationService();
            var location = service.GetLocationById(id);
            return Ok(location);
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] LocationCreate location)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var service = CreateLocationService();
            if (!service.CreateLocation(location)) return InternalServerError();

            return Ok("Location sucessfully created.");
        }

        [HttpPut]
        public IHttpActionResult Put([FromBody] LocationEdit location)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var service = CreateLocationService();
            if (!service.UpdateLocation(location)) return InternalServerError();

            return Ok("Location successfully updated.");
        }

        [HttpDelete]
        public IHttpActionResult Delete([FromUri] int id)
        {
            var service = CreateLocationService();
            if (!service.DeleteLocation(id)) return InternalServerError();
            return Ok("Location successfully deleted.");
        }
    }
}
