namespace EntitiesLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("StavkePrimke")]
    public partial class StavkePrimke
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PrimkaID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ArtiklID { get; set; }

        public int? Kolicina { get; set; }

        public virtual Artikl Artikl { get; set; }

        public virtual Primka Primka { get; set; }
    }
}
