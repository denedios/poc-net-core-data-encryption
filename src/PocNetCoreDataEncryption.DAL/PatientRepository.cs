using PocNetCoreDataEncryption.Domain;
using PocNetCoreDataEncryption.Domain.Entities;

namespace PocNetCoreDataEncryption.DAL
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(Context context) : base(context)
        {
            
        }
    }
}