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
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nazwa { get; set; }
        [Required]
        public string RFIDTag { get; set; }
        [Required]
        [Display(Name = "Data waznosci produktu")]
        public DateTime DataWaznosci { get; set; }
    }
}
