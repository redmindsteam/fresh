namespace Fresh.Service.ViewModels.ViewDetails
{
    public class CheckDetailsView
    {
        public string ProductName { get; set; } = string.Empty;
        public float PricePerUnit { get; set; }
        public float Quantity { get; set; }
        public float TotalPrice { get; set; }
    }
}
