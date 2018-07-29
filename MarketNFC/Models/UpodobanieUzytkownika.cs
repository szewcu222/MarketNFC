using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketNFC.Models
{
    [Table("UpodobaniaUzytkownika")]
    public class UpodobanieUzytkownika
    {
        [ForeignKey("Uzytkownik")]
        public string  UzytkownikId { get; set; }
        public Uzytkownik Uzytkownik { get; set; }

        [ForeignKey("Produkt")]
        public int ProduktId { get; set; }
        public Produkt Produkt { get; set; }
    }
}
