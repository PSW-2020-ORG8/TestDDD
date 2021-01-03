using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model.Pharmacy;
using Repository;

namespace Backend.Repository.PharmacyRepository
{
    public interface IPharmacyRepository : IRepository<Pharmacies, int>
    {

    }
}
