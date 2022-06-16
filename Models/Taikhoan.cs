namespace WedBH.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Taikhoan")]
    public partial class Taikhoan
    {
        [Key]
        [StringLength(150)]
        [Required(ErrorMessage = "Bạn phải nhập tên tài khoản")]
        public string TK { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập mật khẩu tài khoản")]
        [StringLength(150)]
        public string MK { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập mã chức vụ tài khoản")]
        public int MACV { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tên người dùng")]
        [StringLength(60)]
        public string TEN { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập số điện thoại người dùng")]
        [RegularExpression("/((09|03|07|08|05)+([0 - 9]{8})\b)/g", ErrorMessage = "Số điện thoại không hợp lệ")]
        [StringLength(13)]
        public string SDT { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập giới tính")]
        [StringLength(10)]
        public string GIOITINH { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập dịa chỉ")]
        [StringLength(200)]
        public string DIACHI { get; set; }

        public virtual Chucvu Chucvu { get; set; }
    }
}
