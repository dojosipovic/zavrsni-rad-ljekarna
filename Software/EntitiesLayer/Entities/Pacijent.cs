namespace EntitiesLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Pacijent")]
    public partial class Pacijent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pacijent()
        {
            Recept = new HashSet<Recept>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(9)]
        public string MBO { get; set; }

        [Required]
        [StringLength(20)]
        public string Ime { get; set; }

        [Required]
        [StringLength(30)]
        public string Prezime { get; set; }

        [StringLength(200)]
        public string Adresa { get; set; }

        public DateTime? DatumRodenja { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Recept> Recept { get; set; }
    }
}
