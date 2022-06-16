namespace WedBH.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YeucauBD")]
    public partial class YeucauBD
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string MAYC { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(150)]
        public string TK { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mô tả ")]
        [StringLength(250)]
        public string MOTA { get; set; }

        [StringLength(50)]
        public string TRANGTHAI { get; set; }

        public DateTime THOIGIANYEUCAU { get; set; }

        [StringLength(50)]
        public string ANH1 { get; set; }

        [StringLength(50)]
        public string ANH2 { get; set; }

        [StringLength(50)]
        public string ANH3 { get; set; }

        [StringLength(50)]
        public string ANH4 { get; set; }
    }
}
