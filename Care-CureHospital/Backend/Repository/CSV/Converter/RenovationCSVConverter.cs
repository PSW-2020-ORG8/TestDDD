// File:    RenovationCSVConverter.cs
// Author:  Hacer
// Created: ponedeljak, 25. maj 2020. 01:41:55
// Purpose: Definition of Class RenovationCSVConverter

using Model.Term;
using Repository.RoomsRepository;
using System;

namespace Repository.Csv.Converter
{
    public class RenovationCSVConverter : ICSVConverter<Renovation>
    {
        private readonly string delimiter;
        private const string DATETIME_FORMAT = "dd.MM.yyyy.";

        public RenovationCSVConverter(string delimiter)
        {
            this.delimiter = delimiter;
        }

        public string ConvertEntityToCSVFormat(Renovation entity)
        {
            return string.Join(delimiter, entity.GetId(), entity.DescriptionOfRenovation, entity.Room.GetId(), entity.FromDateTime.ToString(DATETIME_FORMAT), entity.ToDateTime.ToString(DATETIME_FORMAT));
        }

        public Renovation ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(delimiter.ToCharArray());
            return new Renovation(int.Parse(tokens[0]), tokens[1], RoomRepository.Instance().GetEntity(int.Parse(tokens[2])), DateTime.Parse(tokens[3]), DateTime.Parse(tokens[4]));
        }

    }
}