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
    public class HeroService
    {
        private readonly Guid _userId;

        public HeroService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateHero(HeroCreate model)
        {
            var entity = new Hero()
            {
                RealFullName = model.RealFullName,
                HeroName = model.HeroName,
                HomeBase = model.HomeBase,
                PowerId = model.PowerId,
                HeroJobId = model.HeroJobId
            };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Heroes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<HeroDetails> GetHeroes()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query = ctx.Heroes.Select(e => new HeroDetails
                {
                    HeroId = e.HeroId,
                    RealFullName = e.RealFullName,
                    HeroName = e.HeroName,
                    HomeBase = e.HomeBase,
                    Power = new PowerDetails()
                    {
                        PowerId = e.PowerId,
                        PowerDescription = e.Power.PowerDescription,
                        PowerRating = e.Power.PowerRating
                    },
                    HeroJob = new HeroJobDetails()
                    {
                        HeroJobId = e.HeroJobId,
                        JobStatus = e.HeroJob.JobStatus,
                        Heroes = e.HeroJob.Heroes.Select(hero => new HeroInHeroJob()
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
                });

                return query.ToArray();
            }
        }

        public HeroDetails GetHeroById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Heroes.Single(e => e.HeroId == id);

                return new HeroDetails
                {
                    HeroId = entity.HeroId,
                    RealFullName = entity.RealFullName,
                    HeroName = entity.HeroName,
                    HomeBase = entity.HomeBase,
                    Power = new PowerDetails()
                    {
                        PowerId = entity.PowerId,
                        PowerDescription = entity.Power.PowerDescription,
                        PowerRating = entity.Power.PowerRating
                    },
                    HeroJob = new HeroJobDetails()
                    {
                        HeroJobId = entity.HeroJobId,
                        JobStatus = entity.HeroJob.JobStatus,
                        Heroes = entity.HeroJob.Heroes.Select(hero => new HeroInHeroJob()
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
                };
            }
        }

        public bool UpdateHero(HeroEdit model)
        {
            using( var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Heroes.Single(e => e.HeroId == model.HeroId);

                entity.HeroId = model.HeroId;
                entity.RealFullName = model.RealFullName;
                entity.HeroName = model.HeroName;
                entity.HomeBase = model.HomeBase;
                entity.PowerId = model.PowerId;
                entity.HeroJobId = model.HeroJobId;

                return ctx.SaveChanges() == 1;            
            }
        }

        public bool DeleteHero(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Heroes.Single(e => e.HeroId == id);

                ctx.Heroes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
