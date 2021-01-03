
// File:    ValidationMedicamentCSVConverter.cs
// Author:  Stefan
// Created: nedelja, 31. maj 2020. 21:09:55
// Purpose: Definition of Class ValidationMedicamentCSVConverter

using Model.AllActors;
using Model.DoctorMenager;
using Repository.UsersRepository;
using System;
using System.Collections.Generic;

namespace Repository.Csv.Converter
{
    public class ValidationMedicamentCSVConverter : ICSVConverter<ValidationOfMedicament>
    {
        private readonly string delimiter;

        public ValidationMedicamentCSVConverter(string delimiter)
        {
            this.delimiter = delimiter;
        }

        public string ConvertEntityToCSVFormat(ValidationOfMedicament entity)
        {
            return string.Join(delimiter, entity.GetId(), entity.Approved, entity.Medicament.GetId(), entity.FeedbackOfValidation.Comment, entity.Doctor.Id);
        }

        public ValidationOfMedicament ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(delimiter.ToCharArray());
            return new ValidationOfMedicament(int.Parse(tokens[0]), bool.Parse(tokens[1]), MedicamentRepository.MedicamentRepository.Instance().GetEntity((int.Parse(tokens[2]))),
                new FeedbackOfValidation(tokens[3]), (Doctor)UserRepository.Instance().GetEntity(int.Parse(tokens[4])));
        }

    }
}