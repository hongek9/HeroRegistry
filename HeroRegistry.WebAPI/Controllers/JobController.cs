using HeroRegistry.Models.JobModels;
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
    public class JobController : ApiController
    {
        private JobService CreateJobService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var jobService = new JobService(userId);
            return jobService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var service = CreateJobService();
            var jobs = service.GetJobs();
            return Ok(jobs);
        }

        [HttpGet]
        public IHttpActionResult Get([FromUri] int id)
        {
            var service = CreateJobService();
            var job = service.GetJobById(id);
            return Ok(job);
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] JobCreate job)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var service = CreateJobService();
            if (!service.CreateJob(job)) return InternalServerError();
            return Ok("Job successfully created.");
        }

        [HttpPut]
        public IHttpActionResult Put([FromBody] JobEdit job)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var service = CreateJobService();
            if (!service.UpdateJob(job)) return InternalServerError();
            return Ok("Job successfully updated.");
        }

        [HttpDelete]
        public IHttpActionResult Delete([FromUri] int id)
        {
            var service = CreateJobService();
            if (!service.DeleteJob(id)) return InternalServerError();
            return Ok("Job successfully deleted.");
        }
    }
}
