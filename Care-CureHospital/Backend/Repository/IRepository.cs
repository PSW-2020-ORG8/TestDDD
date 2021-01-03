// File:    IRepository.cs
// Author:  Stefan
// Created: sreda, 27. maj 2020. 23:34:05
// Purpose: Definition of Interface IRepository

using HealthClinic.Repository;
using System;
using System.Collections.Generic;

namespace Repository
{
    public interface IRepository<E, ID>
         where E : IIdentifiable<ID>
         where ID : IComparable
    {
        E GetEntity(ID id);

        IEnumerable<E> GetAllEntities();

        IEnumerable<E> GetAllNames();

        E AddEntity(E entity);

        void UpdateEntity(E entity);

        void DeleteEntity(E entity);
    }
}