using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MarketNFC.Models.Enums;

namespace MarketNFC.Models
{
    [Table("Zamowienie")]
    public class Zamowienie
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Uzytkownik")]
        public int UzytkownikId { get; set; }
        [ForeignKey("Lodowka")]
        public int LodowkaId { get; set; }
        [Required]
        public DateTime DataZamowienia { get; set; }
        [Required]
        public DateTime DataDostarczenia { get; set; }
        [Required]
        public TypeOrder TypZamowienia { get; set; }

    }
}
