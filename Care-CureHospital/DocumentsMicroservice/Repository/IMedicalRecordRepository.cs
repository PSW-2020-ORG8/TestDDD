using Model.AllActors;
using Model.PatientDoctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentsMicroservice.Repository
{
    public interface IMedicalRecordRepository : IRepository<MedicalRecord, int>
    {
        MedicalRecord GetMedicalRecordByPatient(Patient patient);
    }
}
