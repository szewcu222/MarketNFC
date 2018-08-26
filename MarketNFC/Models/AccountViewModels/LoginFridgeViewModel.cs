using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketNFC.Models.AccountViewModels
{
    public class LoginFridgeViewModel
    {
        public string Email { get; set; }

        public string UserId { get; set; }

        public int FridgeId { get; set; }

        public int Day { get; set; }

        public TimeSpan Time  { get; set; }
    }
}
