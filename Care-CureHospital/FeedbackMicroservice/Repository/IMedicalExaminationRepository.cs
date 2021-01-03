using Model.Term;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackMicroservice.Repository
{
    public interface IMedicalExaminationRepository : IRepository<MedicalExamination, int>
    {
        List<MedicalExamination> GetAllMedicalExaminationsByDoctor(Model.AllActors.Doctor doctor);

        List<MedicalExamination> GetAllMedicalExaminationsByPatient(Model.AllActors.Patient patient);

        List<MedicalExamination> GetAllMedicalExaminationsByRoom(Room room);

        MedicalExamination GetPreviousMedicalExemination(Model.AllActors.Patient patient);

        Boolean GetOccupancyStatus(MedicalExamination medicalExamination);

    }
}
