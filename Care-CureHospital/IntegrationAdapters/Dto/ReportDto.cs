namespace IntegrationAdapters.Dto
{
    public class ReportDto
    {
        public int Id { get; set; }

        public int MedicamentId { get; set; }

        public string MedicamentName { get; set; }

        public int Quantity { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public ReportDto() { }
    }
}
