using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pojekat3.Models
{
    public class TipProizvoda
    {
        [Key]
        [Required]
        public int TipProizvodaID { get; set; }

        [Required]
        [StringLength(10)]
        [DisplayName("Vrsta proizvoda")]
        public string Vrsta { get; set; }

        public ICollection<Proizvod> Proizvod { get; set; }

        
    }
}