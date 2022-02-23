using HeroRegistry.Data;
using HeroRegistry.Models.PowerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroRegistry.Services
{
    public class PowerService
    {
        private readonly Guid _userId;

        public PowerService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePower(PowerCreate model)
        {
            var entity = new Power()
            {
                PowerDescription = model.PowerDescription,
                PowerRating = model.PowerRating
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Powers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PowerDetails> GetPowers()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query = ctx.Powers.Select(e => new PowerDetails
                {
                    PowerId = e.PowerId,
                    PowerDescription = e.PowerDescription,
                    PowerRating = e.PowerRating
                });

                return query.ToArray();
            }
        }

        public PowerDetails GetPowerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Powers.Single(e => e.PowerId == id);
                return new PowerDetails
                {
                    PowerId = query.PowerId,
                    PowerDescription = query.PowerDescription,
                    PowerRating = query.PowerRating
                };

            }
        }

        public bool UpdatePower(PowerDetails model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Powers.Single(e => e.PowerId == model.PowerId);

                query.PowerId = model.PowerId;
                query.PowerDescription = model.PowerDescription;
                query.PowerRating = model.PowerRating;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePower(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Powers.Single(e => e.PowerId == id);

                ctx.Powers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
