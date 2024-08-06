namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Dobavljac")]
    public partial class Dobavljac
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dobavljac()
        {
            Narudzba = new HashSet<Narudzba>();
            Primka = new HashSet<Primka>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(9)]
        public string OIB { get; set; }

        [Required]
        [StringLength(45)]
        public string Naziv { get; set; }

        [Required]
        [StringLength(21)]
        public string IBAN { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(200)]
        public string Adresa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Narudzba> Narudzba { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Primka> Primka { get; set; }
    }
}
