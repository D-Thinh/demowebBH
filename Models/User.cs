namespace WedBH.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [Key]
        [Required(ErrorMessage = "Bạn phải nhập tên tài khoản")]
        [StringLength(150)]
        public string TK { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập mật khẩu tài khoản")]
        [StringLength(150)]
        public string MK { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tên người dùng")]
        [StringLength(60)]
        public string TEN { get; set; }
        /*[RegularExpression("/((09|03|07|08|05)+([0 - 9]{8})\b)/g", ErrorMessage = "Số điện thoại không hợp lệ")]
        [StringLength(10)]*/
        public string SDT { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập gmail người dùng")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail không hợp lệ")]
        [StringLength(100)]
        public string GMAIL { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập mật khẩu xác nhận tài khoản")]
        [StringLength(150)]
        public string MatKhauXacNhan;
    }
}
