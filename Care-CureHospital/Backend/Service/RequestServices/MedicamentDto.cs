namespace IntegrationAdapters.Dto
{
    public class MedicamentDto
    {
        public string Name { get; set; }
        public double Quantity { get; set; }

        public MedicamentDto() { }

        public override string ToString()
        {
            return this.Name + "; " + this.Quantity.ToString();
        }
    }
}
