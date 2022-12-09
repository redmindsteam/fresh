namespace Fresh.Service.ViewModels
{
    public class ConsignmentLetterView
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Cashier { get; set; } = string.Empty;
        public float TotallPrice { get; set; }
    }
}
