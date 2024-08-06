namespace EntitiesLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Podaci")]
    public partial class Podaci
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string Naziv { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(200)]
        public string Adresa { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(11)]
        public string OIB { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(20)]
        public string Telefon { get; set; }

        [Key]
        [Column(Order = 4)]
        public byte[] Logo { get; set; }
    }
}
