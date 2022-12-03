using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresh.Service.ViewModels
{
    public class CashierView
    {
        public int Id { get; set; }

        public string FullName { get; set; }=string.Empty;

        public string Email { get; set; }= string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string PassportSeria { get; set; } = string.Empty;
    }
}
