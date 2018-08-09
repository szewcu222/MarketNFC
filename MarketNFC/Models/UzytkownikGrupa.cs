using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MarketNFC.Facades;

namespace MarketNFC.Models
{
    [Table("UzytkownikGrupa")]
    public class UzytkownikGrupa : IJoinEntity<Uzytkownik>, IJoinEntity<Grupa>
    {
        [ForeignKey("Uzytkownik")]
        public string UzytkownikId { get; set; }
        public Uzytkownik Uzytkownik { get; set; }

        Uzytkownik IJoinEntity<Uzytkownik>.Navigation
        {
            get => Uzytkownik;
            set => Uzytkownik = value;
        }

        [ForeignKey("Grupa")]
        public int GrupaId { get; set; }
        public Grupa Grupa { get; set; }

        Grupa IJoinEntity<Grupa>.Navigation
        {
            get => Grupa;
            set => Grupa = value;
        }
    }
}
