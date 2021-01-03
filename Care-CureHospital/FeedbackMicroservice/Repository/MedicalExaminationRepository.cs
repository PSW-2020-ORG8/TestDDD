using FeedbackMicroservice.Repository.MySQL;
using FeedbackMicroservice.Repository.MySQL.Stream;
using Model.AllActors;
using Model.Term;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackMicroservice.Repository
{
    public class MedicalExaminationRepository : MySQLRepository<MedicalExamination, int>, IMedicalExaminationRepository
    {
        public MedicalExaminationRepository(IMySQLStream<MedicalExamination> stream)
            : base(stream)
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
