using Backend.Model.PatientDoctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentsMicroservice.Service
{
    public interface IMedicalExaminationReportService : IService<MedicalExaminationReport, int>
    {
        public List<MedicalExaminationReport> GetMedicalExaminationReportsForPatient(int patientID);
        public List<MedicalExaminationReport> FindReportsForCommentParameter(int patientID, string comment);
        public List<MedicalExaminationReport> FindReportsForDateParameter(int patientID, string publishingDate);
        public List<MedicalExaminationReport> FindReportsForRoomParameter(int patientID, string numberOfRoom);
        public List<MedicalExaminationReport> FindReportsForDoctorParameter(int patientID, string doctorFullName);
        public List<MedicalExaminationReport> FindReportsUsingAdvancedSearch(int patientId, Dictionary<string, string> searchParameters, List<string> logicOperators);
        public List<MedicalExaminationReport> FindReportsBySearchParameter(int patientId, string searchParameter, string parameterValue);
        public List<MedicalExaminationReport> CalculateLogicalOperationResult(string logicOperator, List<MedicalExaminationReport> firstResult, List<MedicalExaminationReport> secondResult);
        public List<MedicalExaminationReport> FindReportsUsingSimpleSearch(int patientId, string doctor, string date, string comment, string room);
        public List<MedicalExaminationReport> IntersectionOfSimpleSearchReportsResults(List<MedicalExaminationReport> reportsByDoctor, List<MedicalExaminationReport> reportsByDate, List<MedicalExaminationReport> reportsByComment, List<MedicalExaminationReport> reportsByRoom);
        public List<MedicalExaminationReport> FindReportsByDoctorUsingSimpleSearch(int patientId, string doctor);
        public List<MedicalExaminationReport> FindReportsByDateUsingSimpleSearch(int patientId, string date);
        public List<MedicalExaminationReport> FindReportsByCommentUsingSimpleSearch(int patientId, string comment);
        public List<MedicalExaminationReport> FindReportsByRoomUsingSimpleSearch(int patientId, string room);


    }
}
