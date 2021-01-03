// File:    IntSequencer.cs
// Author:  Stefan
// Created: subota, 06. jun 2020. 17:43:31
// Purpose: Definition of Class IntSequencer

using System;

namespace Repository.IDSequencer
{
    public class IntSequencer : ISequencer<int>
    {
        private int nextID;

        public int GenerateID()
        {
            return ++nextID;
        }

        public void Initialize(int initID)
        {
            this.nextID = initID;
        }

    }
}