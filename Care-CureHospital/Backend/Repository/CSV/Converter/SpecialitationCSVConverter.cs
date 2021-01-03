using Model.Doctor;
using Repository.Csv.Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.CSV.Converter
{
    public class SpecialitationCSVConverter : ICSVConverter<Specialitation>
    {
        private readonly string delimiter;

        public SpecialitationCSVConverter(string delimiter)
        {
            this.delimiter = delimiter;
        }

        public Specialitation ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(delimiter.ToCharArray());
            return new Specialitation(int.Parse(tokens[0]), tokens[1]);
        }

        public string ConvertEntityToCSVFormat(Specialitation entity)
        {
            return string.Join(delimiter, entity.GetId(), entity.SpecialitationForDoctor);
        }
    }
}
