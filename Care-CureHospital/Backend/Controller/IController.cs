// File:    IController.cs
// Author:  Stefan
// Created: petak, 29. maj 2020. 23:25:04
// Purpose: Definition of Interface IController

using System;
using System.Collections.Generic;

namespace Controller
{
    public interface IController<E, ID> where E : class
    {
        E GetEntity(ID id);

        IEnumerable<E> GetAllEntities();

        E AddEntity(E entity);

        void UpdateEntity(E entity);

        void DeleteEntity(E entity);

    }
}