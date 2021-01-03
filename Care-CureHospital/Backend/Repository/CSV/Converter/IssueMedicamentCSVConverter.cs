// File:    IssueMedicamentCSVConverter.cs
// Author:  Hacer
// Created: ponedeljak, 25. maj 2020. 01:41:55
// Purpose: Definition of Class IssueMedicamentCSVConverter

using Model.AllActors;
using Model.Doctor;
using Model.DoctorMenager;
using Model.PatientDoctor;
using Repository.UsersRepository;
using System;
using System.Collections.Generic;

namespace Repository.Csv.Converter
{
    public class IssueMedicamentCSVConverter : ICSVConverter<IssueOfMedicaments>
    {
        private readonly string delimiter;

        public IssueMedicamentCSVConverter(string delimiter)
        {
            this.delimiter = delimiter;
        }

        public string ConvertEntityToCSVFormat(IssueOfMedicaments entity)
        {
            String medicamentsCSV = "";
            foreach (Medicament medicament in entity.Medicaments)
            {
                medicamentsCSV += string.Join(delimiter, medicament.GetId());
                medicamentsCSV += delimiter;
            }
            return string.Join(delimiter, entity.GetId(), entity.Receipt, entity.MedicalRecord.GetId(), entity.Doctor.GetId(), medicamentsCSV);
        }

        public IssueOfMedicaments ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(delimiter.ToCharArray());
            List<Medicament> medicaments = new List<Medicament>();
            FillList(medicaments, tokens);
            return new IssueOfMedicaments(int.Parse(tokens[0]), tokens[1], MedicalRecordRepository.MedicalRecordRepository.Instance().GetEntity(int.Parse(tokens[2])),
                (Doctor)UserRepository.Instance().GetEntity(int.Parse(tokens[3])), medicaments);
        }

        private void FillList(List<Medicament> medicaments, string[] tokens)
        {
            int i = 3;
            while (i < tokens.Length - 1)
            {
                int id = int.Parse(tokens[i]);
                medicaments.Add(MedicamentRepository.MedicamentRepository.Instance().GetEntity(int.Parse(tokens[i])));     
                i++;
            }
        }

    }
}