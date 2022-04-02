using EasterRaces.Models.Races.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : Repository<IRace>
    {
        private List<IRace> models;
        public RaceRepository()
        {
            models = new List<IRace>();
        }
        public override IReadOnlyCollection<IRace> Models => models;

        public override void Add(IRace model)
        {
            models.Add(model);
        }

        public override IReadOnlyCollection<IRace> GetAll()
        {
            return Models;
        }

        public override IRace GetByName(string name)
        {
            return models.FirstOrDefault(x=>x.GetType().Name == name);
        }

        public override bool Remove(IRace model)
        {
            return models.Remove(model);
        }
    }
}
