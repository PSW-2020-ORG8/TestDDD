using System;

namespace IntegrationAdapters.Dto
{
    public class EPrescriptionDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string Comment { get; set; }
        public string MedicamentName { get; set; }
        public DateTime PublishingDate { get; set; }
        public EPrescriptionDto() { }
    }
}
