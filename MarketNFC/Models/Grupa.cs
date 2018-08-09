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
    [Table("Grupa")]
    public class Grupa
    {
        // public Grupa()
        // {
        //     UzytkownikGrupy = new HashSet<UzytkownikGrupa>();
        // }

        public Grupa() => Uzytkownicy
            = new JoinCollectionFacade<Uzytkownik, Grupa, UzytkownikGrupa>(this, UzytkownikGrupy);

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int GrupaId { get; set; }
        [Required]
        public string Nazwa { get; set; }


        public virtual Lodowka Lodowka { get; set; }

        public virtual ICollection<UzytkownikGrupa> UzytkownikGrupy { get; set; }

        [NotMapped]
        public ICollection<Uzytkownik> Uzytkownicy { get; set; }
    }
}
