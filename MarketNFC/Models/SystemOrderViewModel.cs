using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketNFC.Models
{
    public class SystemOrderViewModel
    {
        public int Day { get; set; }

        public TimeSpan Time { get; set; }

    }
}
