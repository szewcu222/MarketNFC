﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketNFC.Models
{
    [Table("Grupa")]
    public class Grupa
    {
        public Grupa()
        {
            UzytkownikGrupy = new HashSet<UzytkownikGrupa>();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int GrupaId { get; set; }
        [Required]
        public string Nazwa { get; set; }


        [ForeignKey("Lodowka")]
        public int LodowkaId { get; set; }
        public Lodowka Lodowka { get; set; }

        public virtual ICollection<UzytkownikGrupa> UzytkownikGrupy { get; set; }
    }
}
