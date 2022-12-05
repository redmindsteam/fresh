using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresh.Service.ViewModels
{
    public class VievModelProductLetter
    {
        public string Name { get; set; }  = String.Empty; 
        public string KgL { get; set; } = String.Empty;
        public string Total { get; set; } = String.Empty;
        public string Price { get; set; } = String.Empty;
        public double TotalPrice { get; set; }
    }
}
