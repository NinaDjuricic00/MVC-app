using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pojekat3.Models
{
    public class Proizvod
    {
        [Key]
        [Required]
        public int ProizvodID { get; set;}

      
        [StringLength(23)]
        [DisplayName("Šifra proizvoda")]
        public string SifraProizvoda { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("Naziv proizvoda")]
        public string NazivProizvoda { get; set; }

        [StringLength(500)]
        [DisplayName("Opis proizvoda")]
        public string OpisProizvoda { get; set; }

        [Range(1,10000)]
        [DisplayName("Nabavna cena")]
        public int NabavnaCenaProizvoda { get; set; }

        
        [Range(1,20000)]
        [DisplayName("Prodajna cena")]
        public int ProdajnaCenaProizvoda { get; set; }

        

        public int TipProizvodaID { get; set; }

        public int ZemljaUvozaID { get; set; }

        public virtual TipProizvoda TipProizvoda { get; set; }

        public virtual ZemljaUvoza ZemljaUvoza { get; set; }

        public virtual ICollection<Raspolaze> Raspolaze { get; set; }

    }
}