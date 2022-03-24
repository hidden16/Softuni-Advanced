namespace NavalVessels.Repositories.Entities
{
    using System.Collections.Generic;
    using Models.Contracts;
    using Repositories.Contracts;
    public class VesselRepository : IRepository<IVessel>
    {
        private List<IVessel> models = new List<IVessel>();
        public IReadOnlyCollection<IVessel> Models { get { return models; } }

        public void Add(IVessel model)
        {
            this.models.Add(model);
        }

        public IVessel FindByName(string name)
        {
            var currVessel = this.models.Find(x => x.Name == name);
            if (currVessel == null)
            {
                return null;
            }
            return currVessel;
        }

        public bool Remove(IVessel model)
        {
            if (this.models.Contains(model))
            {
                this.models.Remove(model);
                return true;
            }
            return false;
        }
    }
}
