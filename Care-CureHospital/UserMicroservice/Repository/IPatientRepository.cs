using UserMicroservice.Domain;
namespace UserMicroservice.Repository
{
    public interface IPatientRepository : IRepository<Patient, int>
    {
        public Patient GetPatientByUsername(string username);
    }
}
