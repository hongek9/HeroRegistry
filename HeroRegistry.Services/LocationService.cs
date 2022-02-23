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
    public class LocationService
    {
        private readonly Guid _userId;

        public LocationService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateLocation(LocationCreate model)
        {
            var entity = new Location()
            {
                LocationName = model.LocationName
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Locations.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<LocationDetails> GetLocations()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query = ctx.Locations.Select(e => new LocationDetails
                {
                    LocationId = e.LocationId,
                    LocationName = e.LocationName,
                    Jobs = e.Jobs.Select(job => new JobInLocation()
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
                });

                return query.ToArray();
            }
        }

        public LocationDetails GetLocationById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Locations.Single(e => e.LocationId == id);

                return new LocationDetails()
                {
                    LocationId = entity.LocationId,
                    LocationName = entity.LocationName,
                    Jobs = entity.Jobs.Select(job => new JobInLocation()
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
                };
            }
        }

        public bool UpdateLocation(LocationEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Locations.Single(e => e.LocationId == model.LocationId);

                entity.LocationId = model.LocationId;
                entity.LocationName = model.LocationName;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteLocation(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Locations.Single(e => e.LocationId == id);

                ctx.Locations.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
