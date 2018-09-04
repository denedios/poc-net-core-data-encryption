using System.Collections.Generic;

namespace PocNetCoreDataEncryption.Domain.DTOs
{
    public class PatientDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        
        public virtual List<AddressDto> Addresses { get; set; }
    }
}
