// File:    CSVRepository.cs
// Author:  Stefan
// Created: subota, 06. jun 2020. 18:25:58
// Purpose: Definition of Class CSVRepository

using System;
using System.Collections.Generic;
using System.Linq;
using HealthClinic.Repository;
using Repository;
using Repository.Csv.Stream;
using Repository.IDSequencer;

namespace Repository.Csv
{
    public class CSVRepository<E, ID> : IRepository<E, ID>
         where E : IIdentifiable<ID>
         where ID : IComparable
    {
        public ICSVStream<E> stream;
        public ISequencer<ID> sequencer;

        public CSVRepository(ICSVStream<E> stream, ISequencer<ID> sequencer)
        {
            this.stream = stream;
            this.sequencer = sequencer;
            InitializeId();
        }

        public E AddEntity(E entity)
        {
            entity.SetId(sequencer.GenerateID());
            stream.AppendToFile(entity);
            return entity;
        }

        public void DeleteEntity(E entity)
        {
            var entities = stream.ReadAll().ToList();
            var entityToRemove = entities.SingleOrDefault(ent => ent.GetId().CompareTo(entity.GetId()) == 0);
            if (entityToRemove != null)
            {
                entities.Remove(entityToRemove);
                stream.SaveAll(entities);
            }
        }

        public IEnumerable<E> GetAllEntities()
        {
            return stream.ReadAll();
        }

        public IEnumerable<E> GetAllNames(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<E> GetAllNames()
        {
            throw new NotImplementedException();
        }

        public E GetEntity(ID id)
        {
            return stream.ReadAll().SingleOrDefault(entity => entity.GetId().CompareTo(id) == 0);
        }

        public void UpdateEntity(E entity)
        {
            var entities = stream.ReadAll().ToList();
            entities[entities.FindIndex(ent => ent.GetId().CompareTo(entity.GetId()) == 0)] = entity;
            stream.SaveAll(entities);
        }

        protected void InitializeId() => sequencer.Initialize(GetMaxId(stream.ReadAll()));

        private ID GetMaxId(IEnumerable<E> entities)
        {
            return entities.Count() == 0 ? default : entities.Max(entity => entity.GetId()); 
        }

    }
}