using HeroRegistry.Data;
using HeroRegistry.Models.HeroJobModels;
using HeroRegistry.Models.HeroModels;
using HeroRegistry.Models.PowerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroRegistry.Services
{
    public class HeroJobService
    {
        private readonly Guid _userId;

        public HeroJobService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateHeroJob(HeroJobCreate model)
        {
            var entity = new HeroJob()
            {
                JobStatus = model.JobStatus
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.HeroJobs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<HeroJobDetails> GetHeroJobs()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query = ctx.HeroJobs.Select(e => new HeroJobDetails
                {
                    HeroJobId = e.HeroJobId,
                    Heroes = e.Heroes.Select(hero => new HeroInHeroJob() { 
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
                       
                    }),
                    JobStatus = e.JobStatus
                });

                return query.ToArray();

            }
        }

        public HeroJobDetails GetHeroJobById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.HeroJobs.Single(e => e.HeroJobId == id);

                return new HeroJobDetails()
                {
                    HeroJobId = entity.HeroJobId,
                    Heroes = entity.Heroes.Select(hero => new HeroInHeroJob()
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
                    }),
                    JobStatus = entity.JobStatus
                };
            }
        }

        public bool UpdateHeroJob(HeroJobEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.HeroJobs.Single(e => e.HeroJobId == model.HeroJobId);

                entity.HeroJobId = model.HeroJobId;
                entity.JobStatus = model.JobStatus;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteHeroJob(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.HeroJobs.Single(e => e.HeroJobId == id);

                ctx.HeroJobs.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
