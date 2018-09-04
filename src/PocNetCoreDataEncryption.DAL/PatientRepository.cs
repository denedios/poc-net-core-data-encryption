using PocNetCoreDataEncryption.Domain;

namespace PocNetCoreDataEncryption.DAL
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(Context context) : base(context)
        {
            
        }
    }
}