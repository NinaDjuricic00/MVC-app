using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pojekat3.Models
{
    public class Raspolaze
    {
        [Key]
        [Required]
        public int RaspolazeID { get; set; }

        
        [Range(1,15000)]
        [DisplayName("Količina")]
        public int Kolicina { get; set; }

        [Required]
        [DisplayName("Cena proizvoda")]
        public int CenaProizvoda { get; set; }

        [Required]
        [DisplayName("Status raspoloživosti")]
        public bool StatusRaspolozivosti { get; set; }


        public int ProizvodID { get; set; }
        public int DrogerijaID { get; set; }
        public virtual Drogerija Drogerija { get; set; }

        public virtual Proizvod Proizvod { get; set; }



    }
}