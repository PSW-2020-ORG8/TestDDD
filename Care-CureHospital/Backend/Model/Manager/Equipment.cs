/***********************************************************************
 * Module:  Equipment.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Manager.Equipment
 ***********************************************************************/

using HealthClinic.Repository;
using System;

namespace Model.Manager
{
    public class Equipment : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string TypeOfEquipment { get; set; }
        public int Amount { get; set; }

        public Equipment(int id)
        {
            Id = id;
        }

        public Equipment()
        {
        }

        public Equipment(int id, string code, string name, string typeOfEquipment, int amount)
        {
            Code = code;
            Name = name;
            TypeOfEquipment = typeOfEquipment;
            Amount = amount;
            Id = id;
        }

        public Equipment(string code, string name, string typeOfEquipment, int amount)
        {
            Code = code;
            Name = name;
            TypeOfEquipment = typeOfEquipment;
            Amount = amount;
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