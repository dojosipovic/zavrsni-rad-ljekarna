namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Primka")]
    public partial class Primka
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Primka()
        {
            StavkePrimke = new HashSet<StavkePrimke>();
        }

        public int ID { get; set; }

        public DateTime DatumKnjizenja { get; set; }

        public int DobavljacID { get; set; }

        public int? NarudzbaID { get; set; }

        public int FarmaceutID { get; set; }

        public virtual Dobavljac Dobavljac { get; set; }

        public virtual Farmaceut Farmaceut { get; set; }

        public virtual Narudzba Narudzba { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StavkePrimke> StavkePrimke { get; set; }
    }
}
