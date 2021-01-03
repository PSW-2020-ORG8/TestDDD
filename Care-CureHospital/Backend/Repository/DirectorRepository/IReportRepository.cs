using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repository;
using Backend.Model.DoctorMenager;

namespace Backend.Repository.DirectorRepository
{
    public interface IReportRepository : IRepository<Report, int>
    {
    }
}
