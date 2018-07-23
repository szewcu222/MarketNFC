using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketNFC.Models
{
    [Table("StanLodowki")]
    public class StanLodowki
    {
        [ForeignKey("Lodowka")]
        public int LodowkaId { get; set; }
        [ForeignKey("Produkt")]
        public int ProduktId { get; set; }
    }
}
