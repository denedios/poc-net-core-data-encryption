using System.Collections.Generic;

namespace PocNetCoreDataEncryption.Domain.Entities
{
    public class Patient : IEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }


        public virtual List<Address> Addresses { get; set; }
    }
}
