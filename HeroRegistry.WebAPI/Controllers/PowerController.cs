using HeroRegistry.Models.PowerModels;
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
    public class PowerController : ApiController
    {
        [Authorize]
        private PowerService CreatePowerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var powerService = new PowerService(userId);
            return powerService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            PowerService powerService = CreatePowerService();
            var powers = powerService.GetPowers();
            return Ok(powers);
        }

        [HttpGet]
        public IHttpActionResult Get([FromUri] int id)
        {
            var service = CreatePowerService();
            var power = service.GetPowerById(id);
            return Ok(power);
        }

        [HttpPost]
        public IHttpActionResult Post(PowerCreate power)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var service = CreatePowerService();

            if (!service.CreatePower(power)) return InternalServerError();

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put([FromBody] PowerDetails power)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var service = CreatePowerService();

            if (!service.UpdatePower(power)) return InternalServerError();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete([FromUri] int id)
        {
            var service = CreatePowerService();

            if (!service.DeletePower(id)) return InternalServerError();

            return Ok();
        }
    }
}
