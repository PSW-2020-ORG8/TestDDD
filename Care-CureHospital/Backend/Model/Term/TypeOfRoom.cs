/***********************************************************************
 * Module:  TypeOfRoom.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Term.TypeOfRoom
 ***********************************************************************/

using HealthClinic.Repository;
using System;

namespace Model.Term
{
    public class TypeOfRoom : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string NameOfType { get; set; }

        public TypeOfRoom()
        {
        }

        public TypeOfRoom(string nameOfType)
        {
            NameOfType = nameOfType;
        }

        public TypeOfRoom(int id, string nameOfType)
        {
            Id = id;
            NameOfType = nameOfType;
        }

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }

    }
}