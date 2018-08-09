using MarketNFC.Facades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketNFC.Models
{
    [Table("ZamowienieProdukt")]
    public class ZamowienieProdukt : IJoinEntity<Zamowienie>, IJoinEntity<Produkt>
    {
        public int Ilosc { get; set; }

        [ForeignKey("Zamowienie")]
        public int ZamowienieId { get; set; }
        public Zamowienie Zamowienie { get; set; }

        Zamowienie IJoinEntity<Zamowienie>.Navigation
        {
            get => Zamowienie;
            set => Zamowienie = value;
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
