namespace EntitiesLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Recept")]
    public partial class Recept
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Recept()
        {
            StavkeRecepta = new HashSet<StavkeRecepta>();
        }

        public int ID { get; set; }

        public DateTime Datum { get; set; }

        public int LijecnikID { get; set; }

        public int PacijentID { get; set; }

        public virtual Lijecnik Lijecnik { get; set; }

        public virtual Pacijent Pacijent { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StavkeRecepta> StavkeRecepta { get; set; }
    }
}
