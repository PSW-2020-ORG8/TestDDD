using Backend.Repository.MySQL.Stream;
using HealthClinic.Repository;
using Repository;
using Repository.IDSequencer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Repository.MySQL
{
    public class MySQLRepository<E, ID> : IRepository<E, ID>
        where E : IIdentifiable<ID>
        where ID : IComparable
    {

        public IMySQLStream<E> stream;
        public ISequencer<ID> sequencer;

        public MySQLRepository(IMySQLStream<E> stream, ISequencer<ID> sequencer)
        {
            this.stream = stream;
            this.sequencer = sequencer;
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

        public IEnumerable<E> GetAllNames()
        {
            throw new NotImplementedException();
        }

        /*public IEnumerable<E> GetAllNames(string name)
        {
            throw new NotImplementedException();
        }
        */
    }
}
