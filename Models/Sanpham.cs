namespace WedBH.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sanpham")]
    public partial class Sanpham
    {
        [Key]
        [StringLength(10)]
        public string MASP { get; set; }

        [Required]
        [StringLength(70)]
        public string TENSP { get; set; }

        [Column(TypeName = "money")]
        public decimal GIA { get; set; }
    }
}
