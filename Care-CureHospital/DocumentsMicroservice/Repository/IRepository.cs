using HealthClinic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentsMicroservice.Repository
{
    public interface IRepository<E, ID>
         where E : IIdentifiable<ID>
         where ID : IComparable
    {
        E GetEntity(ID id);

        IEnumerable<E> GetAllEntities();

        E AddEntity(E entity);

        void UpdateEntity(E entity);

        void DeleteEntity(E entity);
    }
}
