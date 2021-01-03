// File:    EquipmentCSVConverter.cs
// Author:  Hacer
// Created: ponedeljak, 25. maj 2020. 01:41:55
// Purpose: Definition of Class EquipmentCSVConverter

using Model.Manager;
using System;

namespace Repository.Csv.Converter
{
    public class EquipmentCSVConverter : ICSVConverter<Equipment>
    {
        private readonly string delimiter;

        public EquipmentCSVConverter(string delimiter)
        {
            this.delimiter = delimiter;
        }

        public string ConvertEntityToCSVFormat(Equipment entity)
        {
            return string.Join(delimiter, entity.GetId(), entity.Code, entity.Name, entity.TypeOfEquipment, entity.Amount);
        }

        public Equipment ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(delimiter.ToCharArray());
            return new Equipment(int.Parse(tokens[0]), tokens[1], tokens[2], tokens[3], int.Parse(tokens[4]));
        }

    }
}