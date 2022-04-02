using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public abstract class Repository<T> : IRepository<T>
    {
        public abstract IReadOnlyCollection<T> Models { get; }
        public abstract void Add(T model);

        public abstract IReadOnlyCollection<T> GetAll();
        public abstract T GetByName(string name);

        public abstract bool Remove(T model);
    }
}
