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
        public Produkt()
        {
            StanLodowki = new HashSet<StanLodowki>();
            ZamowienieProdukty = new HashSet<ZamowienieProdukt>();
            UpodobanieUzytkownikow = new HashSet<UpodobanieUzytkownika>();
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

        public int GlobalnyNumerJednostkiHandlowej{ get; set; }

        public int NumerPartiiProdukcyjnej { get; set; }

        public float Cena { get; set; }

        public virtual ICollection<StanLodowki> StanLodowki{ get; set; }

        public virtual ICollection<ZamowienieProdukt> ZamowienieProdukty{ get; set; }

        public virtual ICollection<UpodobanieUzytkownika> UpodobanieUzytkownikow { get; set; }

    }
}
