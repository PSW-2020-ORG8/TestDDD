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
    public class MedicalExaminationRepository : MySQLRepository<MedicalExamination, int>, IMedicalExaminationRepository
    {
        private const string MEDICALEXAMINATION_FILE = "../../Resources/Data/medicalexaminations.csv";
        private static MedicalExaminationRepository instance;

        public static MedicalExaminationRepository Instance()
        {
            if(instance == null)
            {
                instance = new MedicalExaminationRepository(new MySQLStream<MedicalExamination>(), new IntSequencer());
            }        
                return instance;        
        }

        public MedicalExaminationRepository(IMySQLStream<MedicalExamination> stream, ISequencer<int> sequencer)
            : base(stream, sequencer)
        {
        }

        public List<MedicalExamination> GetAllMedicalExaminationsByDoctor(Doctor doctor)
        {
            List<MedicalExamination> medicalExaminations = new List<MedicalExamination>();
            foreach (MedicalExamination medicalExamination in GetAllEntities())
                if (medicalExamination.Doctor.GetId() == doctor.GetId())
                    medicalExaminations.Add(medicalExamination);
            return medicalExaminations;
        }


        public List<MedicalExamination> GetAllMedicalExaminationsByPatient(Patient patient)
        {
            List<MedicalExamination> medicalExaminations = new List<MedicalExamination>();
            foreach (MedicalExamination medicalExamination in GetAllEntities())
                if (medicalExamination.Patient.GetId() == patient.GetId())
                    medicalExaminations.Add(medicalExamination);
            return medicalExaminations;
        }

        public List<MedicalExamination> GetAllMedicalExaminationsByRoom(Room room)
        {
            List<MedicalExamination> medicalExaminations = new List<MedicalExamination>();
            foreach (MedicalExamination medicalExamination in GetAllEntities())
                if (medicalExamination.Room.GetId() == room.GetId())
                    medicalExaminations.Add(medicalExamination);
            return medicalExaminations;
        }

        public bool GetOccupancyStatus(MedicalExamination medicalExamination)
        {
            throw new NotImplementedException();
        }

        public MedicalExamination GetPreviousMedicalExemination(Patient patient)
        {
            throw new NotImplementedException();
        }
    }
}