using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketNFC.Models
{
    [Table("ZamowienieProdukt")]
    public class ZamowienieProdukt
    {
        [ForeignKey("Zamowienie")]
        public int ZamowienieId { get; set; }
        [ForeignKey("Produkt")]
        public int ProduktId { get; set; }
    }
}
