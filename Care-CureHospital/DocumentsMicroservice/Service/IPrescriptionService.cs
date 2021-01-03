using Backend.Model.PatientDoctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentsMicroservice.Service
{
    public interface IPrescriptionService : IService<Prescription, int>
    {
        public List<Prescription> GetPrescriptionsForPatient(int patientID);
        public List<Prescription> FindPrescriptionsForCommentParameter(int patientID, string comment);
        public List<Prescription> FindPrescriptionsForDateParameter(int patientID, string publishingDate);
        public List<Prescription> FindPrescriptionsForDoctorParameter(int patientID, string doctorFullName);
        public List<Prescription> FindPrescriptionsForMedicamentsParameter(int patientID, string medicaments);
        public List<Prescription> FindPrescriptionsUsingAdvancedSearch(int patientId, Dictionary<string, string> searchParameters, List<string> logicOperators);
        public List<Prescription> FindPrescriptionsBySearchParameter(int patientId, string searchParameter, string parameterValue);
        public List<Prescription> CalculateLogicalOperationResult(string logicOperator, List<Prescription> firstResult, List<Prescription> secondResult);
        public List<Prescription> FindPrescriptionsUsingSimpleSearch(int patientId, string doctor, string date, string comment, string medicaments);
        public List<Prescription> IntersectionOfSimpleSearchPrescriptionsResults(List<Prescription> prescriptionsByDoctor, List<Prescription> prescriptionsByDate, List<Prescription> prescriptionsByComment, List<Prescription> prescriptionsByMedicaments);
        public List<Prescription> FindPrescriptionsByDoctorUsingSimpleSearch(int patientId, string doctor);
        public List<Prescription> FindPrescriptionsByDateUsingSimpleSearch(int patientId, string date);
        public List<Prescription> FindPrescriptionsByCommentUsingSimpleSearch(int patientId, string comment);
        public List<Prescription> FindPrescriptionsByMedicamentsUsingSimpleSearch(int patientId, string medicaments);


    }
}
