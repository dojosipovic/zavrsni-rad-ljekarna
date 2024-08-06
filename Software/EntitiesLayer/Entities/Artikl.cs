namespace EntitiesLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Artikl")]
    public partial class Artikl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Artikl()
        {
            StavkeNarudzbe = new HashSet<StavkeNarudzbe>();
            StavkePrimke = new HashSet<StavkePrimke>();
            StavkeRacuna = new HashSet<StavkeRacuna>();
            StavkeRecepta = new HashSet<StavkeRecepta>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(45)]
        public string Naziv { get; set; }

        public double Cijena { get; set; }

        public int Kolicina { get; set; }

        [Required]
        [StringLength(3)]
        public string JedinicaMjereID { get; set; }

        public virtual JedinicaMjere JedinicaMjere { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StavkeNarudzbe> StavkeNarudzbe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StavkePrimke> StavkePrimke { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StavkeRacuna> StavkeRacuna { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StavkeRecepta> StavkeRecepta { get; set; }
    }
}
