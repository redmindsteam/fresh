using Fresh.Domain.Common;

namespace Fresh.Domain.Entities
{
    public class Product : BaseEntity
    {
        
        public string Name { get; set; } = string.Empty;

        public int CategoryId { get; set; }

        public float Price { get; set; }

        public string Unit { get; set; } = string.Empty;

        public string BarcodeName { get; set; } = string.Empty;

        public string ProductionDate { get; set; } = string.Empty;

        public string ExpireDate { get; set; } = string.Empty;

        public float Value { get; set; }
    }
}
