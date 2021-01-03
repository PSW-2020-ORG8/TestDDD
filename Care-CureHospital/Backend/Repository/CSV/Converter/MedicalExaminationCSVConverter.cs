// File:    MedicalExaminationCSVConverter.cs
// Author:  Hacer
// Created: ponedeljak, 25. maj 2020. 01:41:55
// Purpose: Definition of Class MedicalExaminationCSVConverter

using Model.AllActors;
using Model.Term;
using Repository.UsersRepository;
using System;

namespace Repository.Csv.Converter
{
    public class MedicalExaminationCSVConverter : ICSVConverter<MedicalExamination>
    {
        private readonly string delimiter;
        private const string DATETIME_FORMAT = "dd.MM.yyyy. HH:mm";

        public MedicalExaminationCSVConverter(string delimiter)
        {
            this.delimiter = delimiter;
        }

        public string ConvertEntityToCSVFormat(MedicalExamination entity)
        {
            return string.Join(delimiter, entity.GetId(), entity.SurveyFilled, entity.ShortDescription, entity.Room.GetId(),
                entity.Doctor.GetId(), entity.Patient.GetId(), entity.FromDateTime.ToString(DATETIME_FORMAT), entity.ToDateTime.ToString(DATETIME_FORMAT));
        }

        public MedicalExamination ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(delimiter.ToCharArray());           
            return new MedicalExamination(int.Parse(tokens[0]), bool.Parse(tokens[1]), tokens[2], RoomsRepository.RoomRepository.Instance().GetEntity(int.Parse(tokens[3])),
            (Doctor)UserRepository.Instance().GetEntity(int.Parse(tokens[4])), (Patient)UserRepository.Instance().GetEntity(int.Parse(tokens[5])), 
            DateTime.Parse(tokens[6]), DateTime.Parse(tokens[7]));
        }

    }
}