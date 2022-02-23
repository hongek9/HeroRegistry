using HeroRegistry.Models.HeroJobModels;
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
    public class HeroJobController : ApiController
    {
        private HeroJobService CreateHeroJobService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var heroJobService = new HeroJobService(userId);
            return heroJobService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var service = CreateHeroJobService();
            var heroJobs = service.GetHeroJobs();
            return Ok(heroJobs);
        }

        [HttpGet]
        public IHttpActionResult Get([FromUri] int id)
        {
            var service = CreateHeroJobService();
            var heroJob = service.GetHeroJobById(id);
            return Ok(heroJob);
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] HeroJobCreate heroJob)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var service = CreateHeroJobService();
            if (!service.CreateHeroJob(heroJob)) return InternalServerError();

            return Ok("Herojob sucessfully created.");
        }

        [HttpPut]
        public IHttpActionResult Put([FromBody] HeroJobEdit heroJob)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var service = CreateHeroJobService();
            if (!service.UpdateHeroJob(heroJob)) return InternalServerError();

            return Ok("HeroJob sucessfully updated.");
        }

        [HttpDelete]
        public IHttpActionResult Delete([FromUri] int id)
        {
            var service = CreateHeroJobService();
            if (!service.DeleteHeroJob(id)) return InternalServerError();
            return Ok("HeroJob sucessfully deleted.");
        }
    }
}
