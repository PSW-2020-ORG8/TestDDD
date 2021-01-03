using HealthClinic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model.DoctorMenager
{
    public class Report : IIdentifiable<int>
    {
        public int Id { get; set; }

        public int MedicamentId { set; get; }

        public String MedicamentName { get; set; }

        public int Quantity { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public Report(int id, int medicamentId, string name, int quantity, DateTime fromDate, DateTime toDate)
        {
            Id = id;

            MedicamentId = medicamentId;

            MedicamentName = name;

            Quantity = quantity;

            FromDate = fromDate;

            ToDate = toDate;

        }

        public Report(string name, int quantity)
        {

            MedicamentName = name;

            Quantity = quantity;
            
        }


        public Report(String name)
        {
            MedicamentName = name;
        }

        public Report()
        {

        }

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }


    }
}
