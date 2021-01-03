// File:    ICSVStream.cs
// Author:  Hacer
// Created: ponedeljak, 25. maj 2020. 01:43:34
// Purpose: Definition of Interface ICSVStream

using System;
using System.Collections.Generic;

namespace Repository.Csv.Stream
{
    public interface ICSVStream<E>
    {
        void SaveAll(IEnumerable<E> entities);

        IEnumerable<E> ReadAll();

        void AppendToFile(E entity);

    }
}