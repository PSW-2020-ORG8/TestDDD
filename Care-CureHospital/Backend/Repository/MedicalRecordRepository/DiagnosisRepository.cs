/***********************************************************************
 * Module:  DiagnosisRepository.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Repository.DiagnosisRepository
 ***********************************************************************/

using Backend.Repository.MySQL;
using Backend.Repository.MySQL.Stream;
using Model.PatientDoctor;
using Repository.Csv;
using Repository.Csv.Converter;
using Repository.Csv.Stream;
using Repository.IDSequencer;
using System;

namespace Repository.MedicalRecordRepository
{
    public class DiagnosisRepository : MySQLRepository<Diagnosis, int>, IDiagnosisRepository
    {

        private const string DIAGNOSIS_FILE = "../../Resources/Data/diagnosis.csv";
        private static DiagnosisRepository instance;

        public static DiagnosisRepository Instance()
        {
            if (instance == null)
            {
                instance = new DiagnosisRepository(new MySQLStream<Diagnosis>(), new IntSequencer());
            }
            return instance;
        }

        public DiagnosisRepository(IMySQLStream<Diagnosis> stream, ISequencer<int> sequencer)
            : base(stream, sequencer)
        {
        }

    }
}