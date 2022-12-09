namespace Fresh.Service.ViewModels
{
    public class StatsView
    {
        public string Date { get; set; } = string.Empty;
        public float Income { get; set; } = 0;
        public float Expenditure { get; set; } = 0;
        public DateTime DateToOrder { get; set; }
    }
}
