using Backend.Model.PatientDoctor;
using Backend.Repository.MySQL;
using Backend.Repository.MySQL.Stream;
using Repository.IDSequencer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repository.ExaminationSurgeryRepository
{
    public class MedicalExaminationReportRepository : MySQLRepository<MedicalExaminationReport, int>, IMedicalExaminationReportRepository
    {

        private static MedicalExaminationReportRepository instance;

        public static MedicalExaminationReportRepository Instance()
        {
            if (instance == null)
            {
                instance = new MedicalExaminationReportRepository(new MySQLStream<MedicalExaminationReport>(), new IntSequencer());
            }
            return instance;
        }

        public MedicalExaminationReportRepository(IMySQLStream<MedicalExaminationReport> stream, ISequencer<int> sequencer)
            : base(stream, sequencer)
        {
        }
    }
}
