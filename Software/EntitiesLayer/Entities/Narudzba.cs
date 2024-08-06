namespace EntitiesLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Narudzba")]
    public partial class Narudzba
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Narudzba()
        {
            Primka = new HashSet<Primka>();
            StavkeNarudzbe = new HashSet<StavkeNarudzbe>();
        }

        public int ID { get; set; }

        public DateTime Datum { get; set; }

        public int DobavljacID { get; set; }

        public int StatusID { get; set; }

        public int FarmaceutID { get; set; }

        public virtual Dobavljac Dobavljac { get; set; }

        public virtual Farmaceut Farmaceut { get; set; }

        public virtual StatusNarudzbe StatusNarudzbe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Primka> Primka { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StavkeNarudzbe> StavkeNarudzbe { get; set; }
    }
}
