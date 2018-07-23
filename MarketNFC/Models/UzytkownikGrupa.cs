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
        public int UzytkownikId { get; set; }
        [ForeignKey("Grupa")]
        public int GrupaId { get; set; }
    }
}
