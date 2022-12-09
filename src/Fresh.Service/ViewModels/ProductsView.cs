namespace Fresh.Service.ViewModels
{
    public class ProductsView
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public float Price { get; set; }

        public float Available { get; set; }
    }
}
