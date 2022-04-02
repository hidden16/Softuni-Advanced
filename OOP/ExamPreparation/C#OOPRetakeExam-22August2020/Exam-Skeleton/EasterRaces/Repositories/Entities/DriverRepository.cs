using EasterRaces.Models.Drivers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : Repository<IDriver>
    {
        private List<IDriver> models;
        public DriverRepository()
        {
            models = new List<IDriver>();
        }
        public override IReadOnlyCollection<IDriver> Models => models;

        public override void Add(IDriver model)
        {
            models.Add(model);
        }

        public override IReadOnlyCollection<IDriver> GetAll()
        {
            return Models;
        }

        public override IDriver GetByName(string name)
        {
            return models.FirstOrDefault(x=>x.GetType().Name == name);
        }

        public override bool Remove(IDriver model)
        {
            return models.Remove(model);
        }
    }
}
