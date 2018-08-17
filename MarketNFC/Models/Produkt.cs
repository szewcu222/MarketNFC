using MarketNFC.Facades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketNFC.Models
{
    [Table("Produkt")]
    public class Produkt
    {
        //public Produkt()
        //{
        //    StanLodowki = new HashSet<StanLodowki>();
        //    ZamowienieProdukty = new HashSet<ZamowienieProdukt>();
        //    UpodobanieUzytkownikow = new HashSet<UpodobanieUzytkownika>();
        //}

        public Produkt()
        {
            Zamowienia = new JoinCollectionFacade<Zamowienie, Produkt, ZamowienieProdukt>(this, ZamowienieProdukty);
            Uzytkownicy = new JoinCollectionFacade<Uzytkownik, Produkt, UpodobanieUzytkownika>(this, UpodobanieUzytkownikow);
            Lodowki= new JoinCollectionFacade<Lodowka, Produkt, StanLodowki>(this, StanLodowki);
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ProduktId { get; set; }
        [Required]
        public string Nazwa { get; set; }
        [Required]
        public string RFIDTag { get; set; }
        [Required]
        [Display(Name = "Data waznosci produktu")]
        public DateTime DataWaznosci { get; set; }

        public string Producent { get; set; }

        public int GlobalnyNumerJednostkiHandlowej { get; set; }

        public int NumerPartiiProdukcyjnej { get; set; }

        public float Cena { get; set; }



        private ICollection<ZamowienieProdukt> ZamowienieProdukty { get; } 
            = new List<ZamowienieProdukt>();

        private ICollection<UpodobanieUzytkownika> UpodobanieUzytkownikow { get; }
            = new List<UpodobanieUzytkownika>();

        private ICollection<StanLodowki> StanLodowki { get; }
            = new List<StanLodowki>();



        [NotMapped]
        public ICollection<Zamowienie> Zamowienia { get; set; }

        [NotMapped]
        public ICollection<Uzytkownik> Uzytkownicy { get; set; }

        [NotMapped]
        public ICollection<Lodowka> Lodowki { get; set; }

    }
}
