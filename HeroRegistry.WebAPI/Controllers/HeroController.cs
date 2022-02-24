using HeroRegistry.Models.HeroModels;
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
    public class HeroController : ApiController
    {
        private HeroService CreateHeroService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var heroService = new HeroService(userId);
            return heroService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var service = CreateHeroService();
            var heroes = service.GetHeroes();
            return Ok(heroes);
        }

        [HttpGet]
        public IHttpActionResult Get([FromUri] int id)
        {
            var service = CreateHeroService();
            var hero = service.GetHeroById(id);
            return Ok(hero);
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] HeroCreate hero)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var service = CreateHeroService();

            if (!service.CreateHero(hero)) return InternalServerError();

            return Ok("Hero sucessfully created.");
         
        }

        [HttpPut]
        public IHttpActionResult Put([FromBody] HeroEdit hero)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var service = CreateHeroService();

            if (!service.UpdateHero(hero)) return InternalServerError();

            return Ok("Hero sucessfully updated.");
        }

        [HttpDelete]
        public IHttpActionResult Delete([FromUri] int id)
        {
            var service = CreateHeroService();
            if (!service.DeleteHero(id)) return InternalServerError();

            return Ok("Hero sucessfully deleted.");
        }
    }
}
