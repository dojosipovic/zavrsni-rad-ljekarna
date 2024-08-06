namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StavkeRecepta")]
    public partial class StavkeRecepta
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ReceptID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ArtiklID { get; set; }

        public int? Kolicina { get; set; }

        public virtual Artikl Artikl { get; set; }

        public virtual Recept Recept { get; set; }
    }
}
