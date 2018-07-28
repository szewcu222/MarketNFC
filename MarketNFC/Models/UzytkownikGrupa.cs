using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketNFC.Models
{
    [Table("UzytkownikGrupa")]
    public class UzytkownikGrupa
    {
        [ForeignKey("Uzytkownik")]
        public string UzytkownikId { get; set; }
        public Uzytkownik Uzytkownik { get; set; }

        [ForeignKey("Grupa")]
        public int GrupaId { get; set; }
        public Grupa Grupa { get; set; }
    }
}
