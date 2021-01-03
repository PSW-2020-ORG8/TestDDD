using DocumentsMicroservice.Repository.MySQL;
using DocumentsMicroservice.Repository.MySQL.Stream;
using Model.AllActors;
using Model.PatientDoctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentsMicroservice.Repository
{
    public class MedicalRecordRepository : MySQLRepository<MedicalRecord, int>, IMedicalRecordRepository
    {
        public MedicalRecordRepository(IMySQLStream<MedicalRecord> stream)
           : base(stream)
        {
        }

        public MedicalRecord GetMedicalRecordByPatient(Patient patient)
        {
            foreach (MedicalRecord medicalRecord in GetAllEntities())
            {
                if (medicalRecord.Patient.GetId() == patient.GetId())
                    return medicalRecord;
            }            
            return null;
        }
    }
}
