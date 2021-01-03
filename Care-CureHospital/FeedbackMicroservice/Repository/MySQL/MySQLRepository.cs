using FeedbackMicroservice.Repository.MySQL.Stream;
using HealthClinic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackMicroservice.Repository.MySQL
{
    public class MySQLRepository<E, ID> : IRepository<E, ID>
        where E : IIdentifiable<ID>
        where ID : IComparable
    {

        public IMySQLStream<E> stream;

        public MySQLRepository(IMySQLStream<E> stream)
        {
            this.stream = stream;
        }

        public E AddEntity(E entity)
        {
            stream.Add(entity);
            stream.SaveAll();
            return entity;
        }

        public void DeleteEntity(E entity)
        {
            var entities = stream.ReadAll().ToList();
            var entityToRemove = entities.SingleOrDefault(ent => ent.GetId().CompareTo(entity.GetId()) == 0);
            if (entityToRemove != null)
            {
                entities.Remove(entityToRemove);
                stream.SaveAll();
            }
        }

        public IEnumerable<E> GetAllEntities()
        {
            return stream.ReadAll();
        }

        public E GetEntity(ID id)
        {
            return stream.ReadAll().SingleOrDefault(entity => entity.GetId().CompareTo(id) == 0);
        }

        public void UpdateEntity(E entity)
        {
            var entities = stream.ReadAll().ToList();
            entities[entities.FindIndex(ent => ent.GetId().CompareTo(entity.GetId()) == 0)] = entity;
            stream.SaveAll();
        }        
    }
}
