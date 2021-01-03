// File:    MedicalRecordCSVConverter.cs
// Author:  Hacer
// Created: ponedeljak, 25. maj 2020. 01:41:55
// Purpose: Definition of Class MedicalRecordCSVConverter

using Model.AllActors;
using Model.DoctorMenager;
using Model.PatientDoctor;
using Repository.UsersRepository;
using System;
using System.Collections.Generic;

namespace Repository.Csv.Converter
{
    public class MedicalRecordCSVConverter : ICSVConverter<MedicalRecord>
    {
        private readonly string delimiter;

        public MedicalRecordCSVConverter(string delimiter)
        {
            this.delimiter = delimiter;
        }

        public string ConvertEntityToCSVFormat(MedicalRecord entity)
        {
            String listOfMedicaments = "";
            String listOfAllergies = "";

            foreach (Allergies allergie in entity.Allergies)
            {
                listOfAllergies += string.Join("-", allergie.Name);
                listOfAllergies += ",";
            }

            foreach (Medicament medicament in entity.Medicaments)
            {
                listOfMedicaments += string.Join("-", medicament.Name);
                listOfMedicaments += "-";
            }

            return string.Join(delimiter, entity.GetId(), entity.Patient.GetId(), entity.Anamnesis, listOfAllergies, listOfMedicaments);
        }

        public MedicalRecord ConvertCSVFormatToEntity(string entityCSVFormat) //l1-l1-l1,l2-l2-l2
        {
            string[] tokens = entityCSVFormat.Split(delimiter.ToCharArray());
            List<Allergies> listOfAllergies = new List<Allergies>();
            fillAllergies(listOfAllergies, tokens);

            List<Medicament> listOfMedicaments = new List<Medicament>();
            fillMedicaments(listOfMedicaments, tokens);

            return new MedicalRecord(int.Parse(tokens[0]), (Patient)UserRepository.Instance().GetEntity(int.Parse(tokens[1])), new Anamnesis(tokens[2]), listOfAllergies, listOfMedicaments);
        }

        private void fillAllergies(List<Allergies> allergies, string[] tokens) //id,1,string,1-2-3,1-2-3
        {
            String[] parts = tokens[3].Split('-');
            foreach(String name in parts)
            {
                allergies.Add(new Allergies(name));
            }
        }

        private void fillMedicaments(List<Medicament> medicaments, string[] tokens)
        {
            String[] parts = tokens[4].Split('-');
            foreach (String name in parts)
            {
                medicaments.Add(new Medicament(name));
            }
        }



    }
}