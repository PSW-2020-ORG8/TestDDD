/***********************************************************************
 * Module:  UserRepository.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Repository.UserRepository
 ***********************************************************************/

using Backend.Repository.MySQL;
using Backend.Repository.MySQL.Stream;
using Model.AllActors;
using Model.Term;
using Repository.Csv;
using Repository.Csv.Converter;
using Repository.Csv.Stream;
using Repository.IDSequencer;
using System;
using System.Collections.Generic;

namespace Repository.ExaminationSurgeryRepository
{
    public class SurgeryRepository : MySQLRepository<Surgery, int>, ISurgeryRepository
    {
        private const string SURGERY_FILE = "../../Resources/Data/surgeries.csv";
        private static SurgeryRepository instance;

        public static SurgeryRepository Instance()
        {
            if (instance == null)
            {
                instance = new SurgeryRepository(new MySQLStream<Surgery>(), new IntSequencer());
            }
            return instance;
        }

        public SurgeryRepository(IMySQLStream<Surgery> stream, ISequencer<int> sequencer)
            : base(stream, sequencer)
        {
        }

        public List<Surgery> GetAllSurgeryByRoom(Room room)
        {
            List<Surgery> surgeries = new List<Surgery>();
            foreach (Surgery surgery in GetAllEntities())
                if (surgery.Room.GetId() == room.GetId())
                    surgeries.Add(surgery);
            return surgeries;
        }

        public List<Surgery> GetAllSurgeryByDoctor(Doctor doctor)
        {
            List<Surgery> surgeries = new List<Surgery>();
            foreach (Surgery surgery in GetAllEntities())
                if (surgery.DoctorSpecialist.GetId() == doctor.GetId())
                    surgeries.Add(surgery);
            return surgeries;
        }

        public List<Surgery> GetAllSurgeryByPatient(Patient patient)
        {
            List<Surgery> surgeries = new List<Surgery>();
            foreach (Surgery surgery in GetAllEntities())
                if (surgery.Patient.GetId() == patient.GetId())
                    surgeries.Add(surgery);
            return surgeries;
        }

        public Surgery GetPreviousSurgery(Patient patient)
        {
            throw new NotImplementedException();
        }
    }
}