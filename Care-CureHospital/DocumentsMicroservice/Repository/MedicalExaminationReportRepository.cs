using Backend.Model.PatientDoctor;
using DocumentsMicroservice.Repository.MySQL;
using DocumentsMicroservice.Repository.MySQL.Stream;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentsMicroservice.Repository
{
    public class MedicalExaminationReportRepository : MySQLRepository<MedicalExaminationReport, int>, IMedicalExaminationReportRepository
    {
        public MedicalExaminationReportRepository(IMySQLStream<MedicalExaminationReport> stream)
            : base(stream)
        {
        }
    }
}
