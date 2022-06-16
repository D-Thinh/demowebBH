namespace WedBH.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTHD")]
    public partial class CTHD
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string MAHD { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MASP { get; set; }

        public int? SL { get; set; }

        public virtual HoaDon HoaDon { get; set; }
    }
}
