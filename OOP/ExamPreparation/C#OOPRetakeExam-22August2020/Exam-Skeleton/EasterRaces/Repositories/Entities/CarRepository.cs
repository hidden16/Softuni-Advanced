using EasterRaces.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : Repository<ICar>
    {
        private List<ICar> models;
        public CarRepository()
        {
            models = new List<ICar>();
        }
        public override IReadOnlyCollection<ICar> Models { get => models; }

        public override void Add(ICar model)
        {
            models.Add(model);
        }

        public override IReadOnlyCollection<ICar> GetAll()
        {
            return models;
        }

        public override ICar GetByName(string name)
        {
            return models.FirstOrDefault(x => x.GetType().Name == name);
        }

        public override bool Remove(ICar model)
        {
            return models.Remove(model);
        }
    }
}
