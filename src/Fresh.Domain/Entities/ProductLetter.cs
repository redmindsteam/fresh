using Fresh.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresh.Domain.Entities
{
    public  class ProductLetter : BaseEntity
    {
       public string ProductDescription { get; set; } = string.Empty;

        public string Date { get; set; } = string.Empty; 

        public int UserId { get; set; } 
    }
}
