// File:    SurgeryCSVConverter.cs
// Author:  Hacer
// Created: ponedeljak, 25. maj 2020. 01:41:55
// Purpose: Definition of Class SurgeryCSVConverter

using Model.AllActors;
using Model.Term;
using Repository.UsersRepository;
using System;

namespace Repository.Csv.Converter
{
    public class SurgeryCSVConverter : ICSVConverter<Surgery>
    {
        private readonly string delimiter;
        private const string DATETIME_FORMAT = "dd.MM.yyyy. HH:mm";

        public SurgeryCSVConverter(string delimiter)
        {
            this.delimiter = delimiter;
        }

        public string ConvertEntityToCSVFormat(Surgery entity)
        {
            return string.Join(delimiter, entity.GetId(), entity.Urgency, entity.ShortDescription, entity.Room.GetId(), entity.DoctorSpecialist.GetId(), 
                entity.Patient.GetId(), entity.FromDateTime.ToString(DATETIME_FORMAT), entity.ToDateTime.ToString(DATETIME_FORMAT));
        }

        public Surgery ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(delimiter.ToCharArray());
            return new Surgery(int.Parse(tokens[0]), bool.Parse(tokens[1]), tokens[2], RoomsRepository.RoomRepository.Instance().GetEntity(int.Parse(tokens[3])), (Model.AllActors.Doctor)UserRepository.Instance().GetEntity(int.Parse(tokens[4])),
                (Patient)UserRepository.Instance().GetEntity(int.Parse(tokens[5])), DateTime.Parse(tokens[6]), DateTime.Parse(tokens[7]));
        }

    }
}