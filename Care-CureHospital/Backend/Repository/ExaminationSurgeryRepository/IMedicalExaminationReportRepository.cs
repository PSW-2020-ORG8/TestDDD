using Backend.Model.PatientDoctor;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repository.ExaminationSurgeryRepository
{
    public interface IMedicalExaminationReportRepository : IRepository<MedicalExaminationReport, int>
    {
    }
}
