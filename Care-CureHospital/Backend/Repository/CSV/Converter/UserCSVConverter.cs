// File:    UserCSVConverter.cs
// Author:  Hacer
// Created: ponedeljak, 25. maj 2020. 01:41:55
// Purpose: Definition of Class UserCSVConverter

using Model.AllActors;
using Model.Doctor;
using Repository.MedicalRecordRepository;
using Repository.UsersRepository;
using System;

namespace Repository.Csv.Converter
{
    public class UserCSVConverter : ICSVConverter<User>
    {
        private readonly string delimiter;
        private const string DATETIME_FORMAT = "dd.MM.yyyy.";

        public UserCSVConverter(string delimiter)
        {
            this.delimiter = delimiter;
        }

        public string ConvertEntityToCSVFormat(User entity)
        {
            
            if (entity.GetType() == typeof(Doctor))
            {
                Doctor doctor = (Doctor)entity;
                return string.Join(delimiter, doctor.GetId(), doctor.GetType(), doctor.Username, doctor.Password, doctor.Name, doctor.Surname,
                    doctor.Jmbg, doctor.DateOfBirth.ToString(DATETIME_FORMAT), doctor.ContactNumber, doctor.EMail, doctor.City.Name,
                    doctor.City.Address, doctor.City.Country.Name, doctor.Specialitation.Id);

            }else if(entity.GetType() == typeof(Patient))
            {
                Patient patient = (Patient)entity;
                return string.Join(delimiter, patient.GetId(), patient.GetType(), patient.Username, patient.Password, patient.Name, patient.Surname, patient.Jmbg, patient.DateOfBirth.ToString(DATETIME_FORMAT),
                    patient.ContactNumber, patient.EMail, patient.City.Name, patient.City.Address, patient.City.Country.Name, patient.GuestAccount);

            }else if(entity.GetType() == typeof(Secretary))
            {
                Secretary secretary = (Secretary)entity;
                return string.Join(delimiter, secretary.GetId(), secretary.GetType(), secretary.Username, secretary.Password, secretary.Name, secretary.Surname, secretary.Jmbg, secretary.DateOfBirth.ToString(DATETIME_FORMAT),
                    secretary.ContactNumber, secretary.EMail, secretary.City.Name, secretary.City.Address, secretary.City.Country.Name);
            }
            else if (entity.GetType() == typeof(Manager))
            {
                Manager manager = (Manager)entity;
                return string.Join(delimiter, manager.GetId(), manager.GetType(), manager.Username, manager.Password, manager.Name, manager.Surname, manager.Jmbg, manager.DateOfBirth.ToString(DATETIME_FORMAT),
                    manager.ContactNumber, manager.EMail, manager.City.Name, manager.City.Address, manager.City.Country.Name);
            }
            return null;
            
        }

        public User ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(delimiter.ToCharArray());
            
            if(tokens[1] == typeof(Doctor).ToString())
            {
                return new Doctor(int.Parse(tokens[0]), tokens[2], tokens[3], tokens[4], tokens[5], tokens[6], DateTime.Parse(tokens[7]), tokens[8], tokens[9],
                    new City(tokens[10], tokens[11], new Country(tokens[12])), SpecialitationRepository.Instance().GetEntity(int.Parse(tokens[13])));

            }else if (tokens[1] == typeof(Patient).ToString())
            {
                return new Patient(int.Parse(tokens[0]), tokens[2], tokens[3], tokens[4], tokens[5], tokens[6], DateTime.Parse(tokens[7]), tokens[8], tokens[9],
                    new City(tokens[10], tokens[11], new Country(tokens[12])), bool.Parse(tokens[13]));
            }
            else if (tokens[1] == typeof(Secretary).ToString())
            {
                return new Secretary(int.Parse(tokens[0]), tokens[2], tokens[3], tokens[4], tokens[5], tokens[6], DateTime.Parse(tokens[7]), tokens[8], tokens[9],
                    new City(tokens[10], tokens[11], new Country(tokens[12])));
            }
            else if (tokens[1] == typeof(Manager).ToString())
            {
                return new Manager(int.Parse(tokens[0]), tokens[2], tokens[3], tokens[4], tokens[5], tokens[6], DateTime.Parse(tokens[7]), tokens[8], tokens[9],
                    new City(tokens[10], tokens[11], new Country(tokens[12])));
            }

            return null;
        }
    }
}