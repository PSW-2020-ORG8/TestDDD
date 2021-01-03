// File:    ISequencer.cs
// Author:  Stefan
// Created: subota, 06. jun 2020. 17:43:30
// Purpose: Definition of Interface ISequencer

using System;

namespace Repository.IDSequencer
{
    public interface ISequencer<T>
    {
        void Initialize(T initID);

        T GenerateID();

    }
}