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

    }
}
