namespace Gym.Repositories
{
    using Models.Equipment.Contracts;
    using Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class EquipmentRepository : IRepository<IEquipment>
    {
        private List<IEquipment> models;
        public EquipmentRepository()
        {
            models = new List<IEquipment>();
        }
        public IReadOnlyCollection<IEquipment> Models { get { return models.AsReadOnly(); } }

        public void Add(IEquipment model)
        {
            models.Add(model);
        }

        public IEquipment FindByType(string type)
        {
            return models.FirstOrDefault(x=>x.GetType().Name == type);
        }

        public bool Remove(IEquipment model)
        {
            return models.Remove(model);
        }
    }
}
