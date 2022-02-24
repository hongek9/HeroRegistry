using HeroRegistry.Data;
using HeroRegistry.Models.HeroJobModels;
using HeroRegistry.Models.HeroModels;
using HeroRegistry.Models.JobModels;
using HeroRegistry.Models.LocationModels;
using HeroRegistry.Models.PowerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroRegistry.Services
{
    public class JobService
    {
        private readonly Guid _userId;

        public JobService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateJob(JobCreate model)
        {
            var entity = new Job()
            {
                JobDescription = model.JobDescription,
                TotalPowerRatingRequired = model.TotalPowerRatingRequired,
                LocationId = model.LocationId,
                HeroJobId = model.LocationId
            };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Jobs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<JobDetails> GetJobs()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query = ctx.Jobs.Select(e => new JobDetails
                {
                    JobId = e.JobId,
                    JobDescription = e.JobDescription,
                    TotalPowerRatingRequired = e.TotalPowerRatingRequired,
                    Location = new LocationDetails
                    {
                        LocationId = e.LocationId,
                        LocationName = e.Location.LocationName,
                        Jobs = e.Location.Jobs.Select(job => new JobInLocation()
                        {
                            JobId = job.JobId,
                            JobDescription = job.JobDescription,
                            TotalPowerRatingRequired = job.TotalPowerRatingRequired,
                            HeroJob = new HeroJobDetails()
                            {
                                HeroJobId = job.HeroJobId,
                                JobStatus = job.HeroJob.JobStatus,
                                Heroes = job.HeroJob.Heroes.Select(hero => new HeroInHeroJob()
                                {
                                    HeroId = hero.HeroId,
                                    RealFullName = hero.RealFullName,
                                    HeroName = hero.HeroName,
                                    HomeBase = hero.HomeBase,
                                    Power = new PowerDetails()
                                    {
                                        PowerId = hero.PowerId,
                                        PowerDescription = hero.Power.PowerDescription,
                                        PowerRating = hero.Power.PowerRating
                                    }
                                })
                            }
                        }).ToList()
                    },
                });

                return query.ToArray();
            }
        }

        public JobDetails GetJobById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Jobs.Single(e => e.JobId == id);
                return new JobDetails()
                {
                    JobId = entity.JobId,
                    JobDescription = entity.JobDescription,
                    TotalPowerRatingRequired = entity.TotalPowerRatingRequired,
                    Location = new LocationDetails
                    {
                        LocationId = entity.LocationId,
                        LocationName = entity.Location.LocationName,
                        Jobs = entity.Location.Jobs.Select(job => new JobInLocation()
                        {
                            JobId = job.JobId,
                            JobDescription = job.JobDescription,
                            TotalPowerRatingRequired = job.TotalPowerRatingRequired,
                            HeroJob = new HeroJobDetails()
                            {
                                HeroJobId = job.HeroJobId,
                                JobStatus = job.HeroJob.JobStatus,
                                Heroes = job.HeroJob.Heroes.Select(hero => new HeroInHeroJob()
                                {
                                    HeroId = hero.HeroId,
                                    RealFullName = hero.RealFullName,
                                    HeroName = hero.HeroName,
                                    HomeBase = hero.HomeBase,
                                    Power = new PowerDetails()
                                    {
                                        PowerId = hero.PowerId,
                                        PowerDescription = hero.Power.PowerDescription,
                                        PowerRating = hero.Power.PowerRating
                                    }
                                })
                            }
                        }).ToList()
                    },
                };
            }
        }

        public bool UpdateJob(JobEdit job)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Jobs.Single(e => e.JobId == job.JobId);

                entity.JobId = job.JobId;
                entity.JobDescription = job.JobDescription;
                entity.TotalPowerRatingRequired = job.TotalPowerRatingRequired;
                entity.LocationId = job.LocationId;
                entity.HeroJobId = job.HeroJobId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteJob(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Jobs.Single(e => e.JobId == id);
                ctx.Jobs.Remove(entity);
                return ctx.SaveChanges() == 1;
            }


        }
    }


}
