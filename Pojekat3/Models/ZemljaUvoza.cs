using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pojekat3.Models
{
    public class ZemljaUvoza
    {
        [Key]
        [Required]
        public int ZemljaUvozaID { get; set; }

        [Required]
        [StringLength(14)]
        [DisplayName("Naziv zemlje")]
        public string Naziv { get; set; }

        public ICollection<Proizvod> Proizvod { get; set; }
    }
}