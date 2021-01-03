using Model.Manager;
using Repository.Csv.Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.CSV.Converter
{
    public class InventaryRoomCSVConverter : ICSVConverter<InventaryRoom>
    {
        private readonly string delimiter;

        public InventaryRoomCSVConverter(string delimiter)
        {
            this.delimiter = delimiter;
        }

        public string ConvertEntityToCSVFormat(InventaryRoom entity)
        {
            return string.Join(delimiter, entity.GetId(), entity.Name, entity.Quantity);
        }

        public InventaryRoom ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(delimiter.ToCharArray());
            return new InventaryRoom(int.Parse(tokens[0]), tokens[1], int.Parse(tokens[2]));
        }
    }
}
