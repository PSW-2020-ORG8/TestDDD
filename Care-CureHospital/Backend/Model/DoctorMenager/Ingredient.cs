/***********************************************************************
 * Module:  Ingredient.cs
 * Author:  Stefan
 * Purpose: Definition of the Class DoctorMenager.Ingredient
 ***********************************************************************/

using System;

namespace Model.DoctorMenager
{
    public class Ingredient
    {
        public string Name { get; set; }

        public Ingredient()
        {
        }

        public Ingredient(string name)
        {
            Name = name;
        }

        
    }
}