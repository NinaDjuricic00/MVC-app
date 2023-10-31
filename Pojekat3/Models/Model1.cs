using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace Pojekat3.Models
{
    public class Model1 : DbContext
    {
       
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Drogerija> Drogerija_set { get; set; }
        public virtual DbSet<Raspolaze> Raspolaze_set { get; set; }
        public virtual DbSet<Proizvod> Proizvod_set { get; set;}
        public virtual DbSet<ZemljaUvoza> ZemljaUvoza_set { get; set; }
        public virtual DbSet<TipProizvoda> TipProizvoda_set { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}