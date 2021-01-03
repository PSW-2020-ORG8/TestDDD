// File:    HospitalitationCSVConverter.cs
// Author:  Hacer
// Created: ponedeljak, 25. maj 2020. 01:41:55
// Purpose: Definition of Class HospitalitationCSVConverter

using Model.Term;
using Model.AllActors;
using Model.Doctor;
using System;
using Repository.RoomsRepository;
using Repository.UsersRepository;

namespace Repository.Csv.Converter
{
    public class HospitalitationCSVConverter : ICSVConverter<Hospitalitation>
    {
        private readonly string delimiter;
        private const string DATETIME_FORMAT = "dd.MM.yyyy. HH:mm";

        public HospitalitationCSVConverter(string delimiter)
        {
            this.delimiter = delimiter;
        }

        public string ConvertEntityToCSVFormat(Hospitalitation entity)
        {
            return string.Join(delimiter, entity.GetId(), entity.Urgency, entity.ShortDescription, entity.Room.GetId(),
                entity.Doctor.GetId(), entity.BedForLaying.GetId(), entity.FromDateTime.ToString(DATETIME_FORMAT), entity.ToDateTime.ToString(DATETIME_FORMAT));
        }

        public Hospitalitation ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(delimiter.ToCharArray());
            return new Hospitalitation(int.Parse(tokens[0]), bool.Parse(tokens[1]), tokens[2], RoomRepository.Instance().GetEntity(int.Parse(tokens[3])),
                (Doctor)UserRepository.Instance().GetEntity(int.Parse(tokens[4])), new Bed(int.Parse(tokens[5])), DateTime.Parse(tokens[6]), DateTime.Parse(tokens[7])); 
        }

    }
}