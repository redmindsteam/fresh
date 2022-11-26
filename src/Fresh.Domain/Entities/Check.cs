using Fresh.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

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
