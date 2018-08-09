using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MarketNFC.Facades;

namespace MarketNFC.Models
{
    [Table("StanLodowki")]
    public class StanLodowki : IJoinEntity<Lodowka>, IJoinEntity<Produkt>
    {
        public int Ilosc { get; set; }

        [ForeignKey("Lodowka")]
        public int LodowkaId { get; set; }
        public Lodowka Lodowka { get; set; }

        Lodowka IJoinEntity<Lodowka>.Navigation
        {
            get => Lodowka;
            set => Lodowka = value;
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
