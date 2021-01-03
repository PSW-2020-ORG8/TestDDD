/***********************************************************************
 * Module:  IssueMedicamentRepository.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Repository.IssueMedicamentRepository
 ***********************************************************************/

using Backend.Repository.MySQL;
using Backend.Repository.MySQL.Stream;
using Model.Doctor;
using Repository.Csv;
using Repository.Csv.Converter;
using Repository.Csv.Stream;
using Repository.IDSequencer;
using System;

namespace Repository.MedicamentRepository
{
    public class IssueOfMedicamentRepository : MySQLRepository<IssueOfMedicaments, int>, IIssueOfMedicamentRepository
    {
        private const string ISSUEOFMEDICAMENTS_FILE = "../../Resources/Data/issueofmedicaments.csv";
        private static IssueOfMedicamentRepository instance;

        public static IssueOfMedicamentRepository Instance()
        {
            if (instance == null)
            {
                instance = new IssueOfMedicamentRepository(new MySQLStream<IssueOfMedicaments>(), new IntSequencer());
            }
            return instance;
        }

        public IssueOfMedicamentRepository(IMySQLStream<IssueOfMedicaments> stream, ISequencer<int> sequencer)
            : base(stream, sequencer)
        {
        }

    }
}