// File:    IService.cs
// Author:  Stefan
// Created: cetvrtak, 28. maj 2020. 03:15:39
// Purpose: Definition of Interface IService

using System;
using System.Collections.Generic;

namespace Service
{
    public interface IService<E, ID> where E : class
    {
        E GetEntity(ID id);

        IEnumerable<E> GetAllEntities();

        E AddEntity(E entity);

        void UpdateEntity(E entity);

        void DeleteEntity(E entity);

    }
}