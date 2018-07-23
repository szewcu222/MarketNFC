using System;
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
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Lodowka")]
        public int LodowkaId { get; set; }
        [Required]
        public string Nazwa { get; set; }
    }
}
