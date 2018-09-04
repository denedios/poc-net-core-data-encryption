namespace PocNetCoreDataEncryption.Domain.DTOs
{
    public class AddressDto
    {
        public int Id { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }
        
        public int PatientId { get; set; }
    }
}