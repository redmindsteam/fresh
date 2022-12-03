﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresh.Service.ViewModels
{
    public class StatsView
    {
        public DateTime Date { get; set; }
        public string Income { get; set; } = string.Empty;
        public string Expenditure { get; set; } = string.Empty;
    }
}
