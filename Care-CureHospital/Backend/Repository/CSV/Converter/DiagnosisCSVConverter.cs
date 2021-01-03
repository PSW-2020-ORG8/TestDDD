// File:    DiagnosisCSVConverter.cs
// Author:  Hacer
// Created: ponedeljak, 25. maj 2020. 01:41:55
// Purpose: Definition of Class DiagnosisCSVConverter

using Model.PatientDoctor;
using System;

namespace Repository.Csv.Converter
{
    public class DiagnosisCSVConverter : ICSVConverter<Diagnosis>
    {
        private readonly string delimiter;

        public DiagnosisCSVConverter(string delimiter)
        {
            this.delimiter = delimiter;
        }

        public string ConvertEntityToCSVFormat(Diagnosis entity)
        {
            return string.Join(delimiter, entity.GetId(), entity.Name);
        }

        public Diagnosis ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(delimiter.ToCharArray());
            return new Diagnosis(int.Parse(tokens[0]), tokens[1]);
        }
        
    }
}