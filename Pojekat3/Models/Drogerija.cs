using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pojekat3.Models
{
    public class Drogerija
    {
        [Key]
        [Required]
        public int DrogerijaID { get; set; }

        [Required]
        [StringLength(30)]
        public string Adresa { get; set; }

        [Required]
        [StringLength(15)]
        [DisplayName("Naziv drogerije")]
        public string Naziv { get; set; }

        [DisplayName("Broj telefona")]
        [StringLength(10)]
        public string BrojTelefona { get; set; }

        [StringLength(9)]
        public string PIB { get; set; }

        public ICollection<Raspolaze> Raspolaze { get; set; }
    }
}