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
    [Table("Zamowienie")]
    public class Zamowienie
    {
        //public Zamowienie()
        //{
        //    ZamowienieProdukty = new HashSet<ZamowienieProdukt>();
        //}
        public Zamowienie() => Produkty = new JoinCollectionFacade<Produkt, Zamowienie, ZamowienieProdukt>(this, ZamowienieProdukty);

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ZamowienieId { get; set; }
        [Required]
        public DateTime DataZamowienia { get; set; }
        [Required]
        public DateTime DataDostarczenia { get; set; }
        [Required]
        public TypeOrder TypZamowienia { get; set; }


        [ForeignKey("Uzytkownik")]
        public string UzytkownikId { get; set; }
        public Uzytkownik Uzytkownik { get; set; }

        [ForeignKey("Lodowka")]
        public int LodowkaId { get; set; }
        public Lodowka Lodowka { get; set; }
        //[JsonIgnore]
        private ICollection<ZamowienieProdukt> ZamowienieProdukty { get; } = new List<ZamowienieProdukt>();

        [NotMapped]
        public ICollection<Produkt> Produkty { get; set; }
    }
}
