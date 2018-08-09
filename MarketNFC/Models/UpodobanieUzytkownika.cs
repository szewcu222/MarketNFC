using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MarketNFC.Facades;

namespace MarketNFC.Models
{
    [Table("UpodobaniaUzytkownika")]
    public class UpodobanieUzytkownika : IJoinEntity<Uzytkownik>, IJoinEntity<Produkt>
    {
        public float WspolczynnikUpodobania { get; set; }

        [ForeignKey("Uzytkownik")]
        public string UzytkownikId { get; set; }
        public Uzytkownik Uzytkownik { get; set; }

        Uzytkownik IJoinEntity<Uzytkownik>.Navigation
        {
            get => Uzytkownik;
            set => Uzytkownik = value;
        }

        [ForeignKey("Produkt")]
        public int ProduktId { get; set; }
        public Produkt Produkt { get; set; }

        Produkt IJoinEntity<Produkt>.Navigation
        {
            get => Produkt;
            set => Produkt = value;
        }
    }
}
