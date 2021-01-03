/***********************************************************************
 * Module:  UserRepository.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Repository.UserRepository
 ***********************************************************************/

using Backend.Repository.MySQL;
using Backend.Repository.MySQL.Stream;
using Model.AllActors;
using Model.Doctor;
using Repository.Csv;
using Repository.Csv.Converter;
using Repository.Csv.Stream;
using Repository.IDSequencer;
using System;
using System.Collections.Generic;

namespace Repository.UsersRepository
{
    public class UserRepository : MySQLRepository<User, int>, IUserRepository
    {
        private const string USER_FILE = "../../Resources/Data/users.csv";
        private static UserRepository instance;

        public static UserRepository Instance()
        {
            if (instance == null)
            {
                instance = new UserRepository(new MySQLStream<User>(), new IntSequencer());
            }
            return instance;
        }

        public UserRepository(IMySQLStream<User> stream, ISequencer<int> sequencer)
         : base(stream, sequencer)
        {
        }

        public List<Doctor> GetAllDoctors()
        {
            List<Doctor> doctors = new List<Doctor>();
            foreach(User user in this.GetAllEntities())
            {
                if (user.GetType() == typeof(Doctor))
                    doctors.Add((Doctor)user);
            }
            return doctors;
        }

        public List<Patient> GetAllPatients()
        {
            List<Patient> patients = new List<Patient>();
            foreach (User user in this.GetAllEntities())
            {
                if (user.GetType() == typeof(Patient))
                    patients.Add((Patient)user);
            }
            return patients;
        }

        public List<Secretary> GetAllSecretaries()
        {
            List<Secretary> secretaries = new List<Secretary>();
            foreach (User user in this.GetAllEntities())
            {
                if (user.GetType() == typeof(Secretary))
                    secretaries.Add((Secretary)user);
            }
            return secretaries;
        }

        public List<Manager> GetAllManagers()
        {
            List<Manager> managers = new List<Manager>();
            foreach (User user in this.GetAllEntities())
            {
                if (user.GetType() == typeof(Manager))
                    managers.Add((Manager)user);
            }
            return managers;
        }

        public User GetUserByUsername(String username)
        {
            foreach (User user in this.GetAllEntities())
            {
                if (user.Username.Equals(username))
                    return user;
            }
            return null;
        }

        public User GetUserByJMBG(String jmbg)
        {
            foreach (User user in this.GetAllEntities())
            {
                if (user.Jmbg.Equals(jmbg))
                    return user;
            }
            return null;
        }

        public List<Doctor> GetDoctorBySpecialitation(Specialitation specialitation)
        {
            List<Doctor> doctors = new List<Doctor>();
            foreach (Doctor doctor in this.GetAllDoctors())
            {
                if (doctor.Specialitation.Equals(specialitation))
                    doctors.Add(doctor);
            }
            return doctors;
        }

        public bool GetOccupancyStatus(Doctor doctor, DateTime time)
        {
            throw new NotImplementedException();
        }

    }
}