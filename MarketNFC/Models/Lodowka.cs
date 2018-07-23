﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketNFC.Models
{
    [Table("Lodowka")]
    public class Lodowka
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Grupa")]
        public int GrupaId { get; set; }
        [Required]
        [Display(Name = "Pojemnosc w [L]")]
        public int Pojemnosc { get; set; }
        public DateTime DataAktualizacji { get; set; }
    }
}
