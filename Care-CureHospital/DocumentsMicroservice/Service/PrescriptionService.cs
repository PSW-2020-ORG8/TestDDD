using Backend.Model.PatientDoctor;
using DocumentsMicroservice.Repository;
using Model.DoctorMenager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentsMicroservice.Service
{
    public class PrescriptionService : IPrescriptionService
    {
        public IPrescriptionRepository prescriptionRepository;

        public PrescriptionService(IPrescriptionRepository prescriptionRepository)
        {
            this.prescriptionRepository = prescriptionRepository;
        }

        public List<Prescription> GetPrescriptionsForPatient(int patientID)
        {
            List<Prescription> prescriptionsForPatient = new List<Prescription>();
            foreach (Prescription prescription in prescriptionRepository.GetAllEntities().ToList())
            {
                if (prescription.MedicalExamination.PatientId == patientID)
                {
                    prescriptionsForPatient.Add(prescription);
                }
            }
            return prescriptionsForPatient;
        }

        public List<Prescription> FindPrescriptionsForCommentParameter(int patientID, string comment)
        {
            List<Prescription> searchResult = new List<Prescription>();
            foreach (Prescription prescription in GetPrescriptionsForPatient(patientID))
            {
                if ((prescription.Comment.ToString().ToLower().Contains(comment.ToLower())))
                {
                    searchResult.Add(prescription);
                }
            }
            return searchResult;
        }

        public List<Prescription> FindPrescriptionsForDateParameter(int patientID, string publishingDate)
        {
            List<Prescription> searchResult = new List<Prescription>();
            foreach (Prescription prescription in GetPrescriptionsForPatient(patientID))
            {
                if ((prescription.PublishingDate.ToString("yyyy-MM-dd").Equals(publishingDate)))
                {
                    searchResult.Add(prescription);
                }
            }
            return searchResult;
        }

        public List<Prescription> FindPrescriptionsForDoctorParameter(int patientID, string doctorFullName)
        {
            List<Prescription> searchResult = new List<Prescription>();
            foreach (Prescription prescription in GetPrescriptionsForPatient(patientID))
            {
                if (doctorFullName.Contains(prescription.MedicalExamination.Doctor.Name.ToString()) || doctorFullName.Contains(prescription.MedicalExamination.Doctor.Surname.ToString()))
                {
                    searchResult.Add(prescription);
                }
            }
            return searchResult;
        }

        public List<Prescription> FindPrescriptionsForMedicamentsParameter(int patientID, string medicaments)
        {
            List<Prescription> searchResult = new List<Prescription>();
            foreach (Prescription prescription in GetPrescriptionsForPatient(patientID))
            {
                foreach (Medicament medicament in prescription.Medicaments)
                {
                    if (medicaments.ToString().ToLower().Contains(medicament.Name.ToString().ToLower()))
                    {
                        searchResult.Add(prescription);
                    }
                }
            }
            return searchResult;
        }

        /// <summary> This method finds prescriptions with maximum four search parameters and logical operator (and, or) between them. </summary>
        public List<Prescription> FindPrescriptionsUsingAdvancedSearch(int patientId, Dictionary<string, string> searchParameters, List<string> logicOperators)
        {
            List<Prescription> currentResult = FindPrescriptionsBySearchParameter(patientId, searchParameters.Keys.ToList()[0], searchParameters.Values.ToList()[0]);
            for (int i = 1; i < searchParameters.Keys.Count; i++)
            {
                List<Prescription> nextResult = FindPrescriptionsBySearchParameter(patientId, searchParameters.Keys.ToList()[i], searchParameters.Values.ToList()[i]);
                currentResult = CalculateLogicalOperationResult(logicOperators[i - 1], currentResult, nextResult);
            }
            return currentResult;
        }

        public List<Prescription> FindPrescriptionsBySearchParameter(int patientId, string searchParameter, string parameterValue)
        {
            if (searchParameter.Equals("Doktoru"))
            {
                return FindPrescriptionsByDoctorUsingSimpleSearch(patientId, parameterValue);
            }
            else if (searchParameter.Equals("Datumu"))
            {
                return FindPrescriptionsByDateUsingSimpleSearch(patientId, parameterValue);
            }
            else if (searchParameter.Equals("Sadržaju"))
            {
                return FindPrescriptionsByCommentUsingSimpleSearch(patientId, parameterValue);
            }
            else if (searchParameter.Equals("Lekovima"))
            {
                return FindPrescriptionsByMedicamentsUsingSimpleSearch(patientId, parameterValue);
            }
            return null;
        }

        public List<Prescription> CalculateLogicalOperationResult(string logicOperator, List<Prescription> firstResult, List<Prescription> secondResult)
        {
            List<Prescription> result = new List<Prescription>();
            if (logicOperator.Equals("I"))
            {
                result = firstResult.Intersect(secondResult).ToList();
            }
            else if (logicOperator.Equals("ILI"))
            {
                result = firstResult.Union(secondResult).ToList();
            }
            return result;
        }

        /// <summary> This method finds prescriptions with maximum four search parameters. </summary>
        public List<Prescription> FindPrescriptionsUsingSimpleSearch(int patientId, string doctor, string date, string comment, string medicaments)
        {
            return IntersectionOfSimpleSearchPrescriptionsResults(FindPrescriptionsByDoctorUsingSimpleSearch(patientId, doctor), FindPrescriptionsByDateUsingSimpleSearch(patientId, date),
                FindPrescriptionsByCommentUsingSimpleSearch(patientId, comment), FindPrescriptionsByMedicamentsUsingSimpleSearch(patientId, medicaments));
        }

        public List<Prescription> IntersectionOfSimpleSearchPrescriptionsResults(List<Prescription> prescriptionsByDoctor, List<Prescription> prescriptionsByDate, List<Prescription> prescriptionsByComment, List<Prescription> prescriptionsByMedicaments)
        {
            List<Prescription> result = prescriptionsByDoctor.Intersect(prescriptionsByDate).ToList();
            result = result.Intersect(prescriptionsByComment).ToList();
            result = result.Intersect(prescriptionsByMedicaments).ToList();

            return result;
        }

        public List<Prescription> FindPrescriptionsByDoctorUsingSimpleSearch(int patientId, string doctor)
        {
            if (doctor == null || doctor.Equals(""))
            {
                return GetPrescriptionsForPatient(patientId).ToList();
            }
            else
            {
                return FindPrescriptionsForDoctorParameter(patientId, doctor);
            }
        }

        public List<Prescription> FindPrescriptionsByDateUsingSimpleSearch(int patientId, string date)
        {
            if (date == null || date.Equals(""))
            {
                return GetPrescriptionsForPatient(patientId).ToList();
            }
            else
            {
                return FindPrescriptionsForDateParameter(patientId, date);
            }
        }

        public List<Prescription> FindPrescriptionsByCommentUsingSimpleSearch(int patientId, string comment)
        {
            if (comment == null || comment.Equals(""))
            {
                return GetPrescriptionsForPatient(patientId).ToList();
            }
            else
            {
                return FindPrescriptionsForCommentParameter(patientId, comment);
            }
        }

        public List<Prescription> FindPrescriptionsByMedicamentsUsingSimpleSearch(int patientId, string medicaments)
        {
            if (medicaments == null || medicaments.Equals(""))
            {
                return GetPrescriptionsForPatient(patientId).ToList();
            }
            else
            {
                return FindPrescriptionsForMedicamentsParameter(patientId, medicaments);
            }
        }

        public Prescription GetEntity(int id)
        {
            return prescriptionRepository.GetEntity(id);
        }

        public IEnumerable<Prescription> GetAllEntities()
        {
            return prescriptionRepository.GetAllEntities();
        }

        public Prescription AddEntity(Prescription entity)
        {
            return prescriptionRepository.AddEntity(entity);
        }

        public void UpdateEntity(Prescription entity)
        {
            prescriptionRepository.UpdateEntity(entity);
        }

        public void DeleteEntity(Prescription entity)
        {
            prescriptionRepository.DeleteEntity(entity);
        }
    }
}
