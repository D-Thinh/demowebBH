namespace WedBH.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Baohiem")]
    public partial class Baohiem
    {
        [Key]
        [StringLength(20)]
        public string MABH { get; set; }

        [Required]
        [StringLength(80)]
        public string TENCHUXE { get; set; }

        [StringLength(13)]
        public string SDT { get; set; }

        [Required]
        [StringLength(10)]
        public string MAPK { get; set; }

        [StringLength(10)]
        public string GIOITINH { get; set; }

        [Required]
        [StringLength(200)]
        public string DIACHI { get; set; }

        [Required]
        [StringLength(20)]
        public string BIENSO { get; set; }

        [StringLength(50)]
        public string SOKHUNG { get; set; }

        [StringLength(50)]
        public string SOMAY { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Date only")]
        [DisplayFormat(DataFormatString = "{MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime THOIHANBD { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Date only")]
        [DisplayFormat(DataFormatString = "{MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime THOIHANKT { get; set; }

        [Column(TypeName = "money")]
        public decimal PHIBH { get; set; }
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail không hợp lệ")]
        [StringLength(75)]
        public string Gmail { get; set; }

        public virtual Phankhoixe Phankhoixe { get; set; }
    }
}
