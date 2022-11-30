using Fresh.Domain.Common;

namespace Fresh.Domain.Entities
{
    public class Check : BaseEntity
    {
        public string CheckDescription { get; set; } = string.Empty;

        public float TotalSum { get; set; }

        public int UserId { get; set; }

        public string Date { get; set; } = string.Empty;
    }
}
