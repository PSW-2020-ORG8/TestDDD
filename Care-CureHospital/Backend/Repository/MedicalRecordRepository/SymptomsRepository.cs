/***********************************************************************
 * Module:  SymptomsRepository.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Repository.SymptomsRepository
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
    public class SymptomsRepository : MySQLRepository<Symptoms, int>, ISymptomsRepository
    {

        private const string SYMPTOMS_FILE = "../../Resources/Data/symptoms.csv";
        private static SymptomsRepository instance;

        public static SymptomsRepository Instance()
        {
            if (instance == null)
            {
                instance = new SymptomsRepository(new MySQLStream<Symptoms>(), new IntSequencer());
            }
            return instance;
        }

        public SymptomsRepository(IMySQLStream<Symptoms> stream, ISequencer<int> sequencer)
            : base(stream, sequencer)
        {
        }

    }
}