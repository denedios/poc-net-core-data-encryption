using Microsoft.EntityFrameworkCore;
using PocNetCoreDataEncryption.DAL2;
using PocNetCoreDataEncryption.Domain.Entities;

namespace PocNetCoreDataEncryption.DAL
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(Context context) : base((DbContext) context)
        {
            
        }
    }
}