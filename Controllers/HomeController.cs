using Commom;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WedBH.Models;

namespace WedBH.Controllers
{
    public class HomeController : Controller
    {
        Model1 db = new Model1();
       // DataContextLinqDataContext data = new DataContextLinqDataContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string shipName, string email, string message)
        {
            string content = System.IO.File.ReadAllText(Server.MapPath("~/client/template/neworder.html"));
            content = content.Replace("{{CustomerName}}", shipName);
            /*content = content.Replace("{{Mobile}}", mobile);*/
            content = content.Replace("{{Email}}", email);
            /*content = content.Replace("{{Name}}", Name);*/
            content = content.Replace("{{Message}}", message);
            // Để Gmail cho phép SmtpClient kết nối đến server SMTP của nó với xác thực 
            //là tài khoản gmail của bạn, bạn cần thiết lập tài khoản email của bạn như sau:
            //Vào địa chỉ https://myaccount.google.com/security  Ở menu trái chọn mục Bảo mật, sau đó tại mục Quyền truy cập 
            //của ứng dụng kém an toàn phải ở chế độ bật
            //  Đồng thời tài khoản Gmail cũng cần bật IMAP
            //Truy cập địa chỉ https://mail.google.com/mail/#settings/fwdandpop
            var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();
            new MailHelper().SendMail(email, "Bảo hành", content);
            new MailHelper().SendMail(toEmail, "Nhận xét của khách", content);
            return Redirect("Index");
        }

    }
}