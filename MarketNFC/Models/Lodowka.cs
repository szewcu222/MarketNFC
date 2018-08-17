using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MarketNFC.Facades;
using MarketNFC.Models.Enums;
using Newtonsoft.Json;

namespace MarketNFC.Models
{
    [Table("Lodowka")]
    public class Lodowka
    {
        // public Lodowka()
        // {
        //     StanLodowki = new HashSet<StanLodowki>();
        //     Zamowienia = new HashSet<Zamowienie>();
        // }

        public Lodowka()
        {
            this.Produkty
                = new JoinCollectionFacade<Produkt, Lodowka, StanLodowki>(this, StanLodowki);
            //StanLodowki = new HashSet<StanLodowki>();
            Zamowienia = new HashSet<Zamowienie>();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int LodowkaId { get; set; }
        [Required]
        [Display(Name = "Pojemnosc w [L]")]
        public int Pojemnosc { get; set; }
        public DateTime DataAktualizacji { get; set; }


        [ForeignKey("Grupa")]
        public int? GrupaId { get; set; }
        public virtual Grupa Grupa { get; set; }

        public virtual ICollection<Zamowienie> Zamowienia { get; set; }


        private ICollection<StanLodowki> StanLodowki { get; }
            = new List<StanLodowki>();

        [NotMapped]
        public ICollection<Produkt> Produkty { get; set; }
    }
}
