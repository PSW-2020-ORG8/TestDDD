using Model.Term;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackMicroservice.Service
{
    public interface IMedicalExaminationService : IService<MedicalExamination, int>
    {
        public List<MedicalExamination> GetByDate(DateTime date);
        public List<MedicalExamination> GetAllMedicalExaminationsByDoctor(Model.AllActors.Doctor doctor);
        public List<MedicalExamination> GetAllMedicalExaminationsByPatient(Model.AllActors.Patient patient);
        public List<MedicalExamination> GetAllMedicalExaminationsByRoom(Model.Term.Room room);
    }
}
