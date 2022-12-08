using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresh.Service.ViewModels.ViewDetails
{
    public class ConsigmentLetterViewDetails
    {
        public string ProductName { get; set; } = string.Empty;
        public float PricePerUnit { get; set; }
        public float Quantity { get; set; }
        public float TotallPrice { get; set; }
    }
}
