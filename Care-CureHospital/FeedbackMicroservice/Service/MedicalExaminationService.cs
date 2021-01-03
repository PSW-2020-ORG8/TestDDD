using FeedbackMicroservice.Repository;
using Model.Term;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackMicroservice.Service
{
    public class MedicalExaminationService : IMedicalExaminationService
    {
        public IMedicalExaminationRepository medicalExaminationRepository;

        public MedicalExaminationService(IMedicalExaminationRepository medicalExaminationRepository)
        {
            this.medicalExaminationRepository = medicalExaminationRepository;
        }

        public List<MedicalExamination> GetByDate(DateTime date)
        {
            List<MedicalExamination> medicalExaminations = new List<MedicalExamination>();
            foreach (MedicalExamination m in medicalExaminationRepository.GetAllEntities())
            {
                if (m.FromDateTime.Equals(date))
                {
                    medicalExaminations.Add(m);
                }
            }

            return medicalExaminations;
        }

        public List<MedicalExamination> GetAllMedicalExaminationsByDoctor(Model.AllActors.Doctor doctor)
        {
            return medicalExaminationRepository.GetAllMedicalExaminationsByDoctor(doctor);
        }

        public List<MedicalExamination> GetAllMedicalExaminationsByPatient(Model.AllActors.Patient patient)
        {
            return medicalExaminationRepository.GetAllMedicalExaminationsByPatient(patient);
        }

        public List<MedicalExamination> GetAllMedicalExaminationsByRoom(Model.Term.Room room)
        {
            return medicalExaminationRepository.GetAllMedicalExaminationsByRoom(room);
        }

        public MedicalExamination GetEntity(int id)
        {
            return medicalExaminationRepository.GetEntity(id);
        }

        public IEnumerable<MedicalExamination> GetAllEntities()
        {
            return medicalExaminationRepository.GetAllEntities();
        }

        public MedicalExamination AddEntity(MedicalExamination entity)
        {
            return medicalExaminationRepository.AddEntity(entity);
        }

        public void UpdateEntity(MedicalExamination entity)
        {
            medicalExaminationRepository.UpdateEntity(entity);
        }

        public void DeleteEntity(MedicalExamination entity)
        {
            medicalExaminationRepository.DeleteEntity(entity);
        }

    }
}
