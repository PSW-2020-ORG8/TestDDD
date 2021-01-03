/***********************************************************************
 * Module:  State.cs
 * Author:  Stefan
 * Purpose: Definition of the Class AllActors.State
 ***********************************************************************/

using System;

namespace Model.AllActors
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Country()
        {
        }

        public Country(string name)
        {
            Name = name;
        }

    }
}