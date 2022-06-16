using Commom;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WedBH.Models;


namespace WedBH.Controllers
{
    public class YeuCauBDController : Controller
    {
        Model2 context = new Model2();
        // GET: YeuCauBD
        public ActionResult ListYeuCau()
        {
            var all_BH = context.YeucauBDs;
            return View(all_BH);
        }
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            YeucauBD bh = context.YeucauBDs.FirstOrDefault(s => s.MAYC == id);
            if (bh == null)
                return HttpNotFound();
            return View(bh);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection collection, string id)
        {
            var E_BH = context.YeucauBDs.First(m => m.MAYC == id);
            var E_MAYC = collection["MAYC"];
            var E_TK = collection["TK"];
            var E_MOTA = collection["MOTA"];
            var E_TRANGTHAI = collection["TRANGTHAI"];
            var E_ANH1 = collection["ANH1"];
            var E_ANH2 = collection["ANH2"];
            var E_ANH3 = collection["ANH3"];
            var E_ANH4 = collection["ANH4"];
            E_BH.MAYC = id;
                if (string.IsNullOrEmpty(E_BH.TK))
                {
                    ViewData["Error"] = "Don't empty!";
                }
                else
                {
                   /* E_BH.MAYC = E_MAYC.ToString();
                    E_BH.TK = E_TK.ToString();
                    E_BH.MOTA = E_MOTA.ToString();*/
                    E_BH.TRANGTHAI = E_TRANGTHAI.ToString();
                   /* E_BH.ANH1 = E_ANH1.ToString();
                    E_BH.ANH2 = E_ANH2.ToString();
                    E_BH.ANH3 = E_ANH3.ToString();
                    E_BH.ANH4 = E_ANH4.ToString();*/
                    UpdateModel(E_BH);
                    context.SaveChanges();
                    return RedirectToAction("ListYeuCau");
                }
            return this.Edit(id);

        }
        public ActionResult Create()
        {
            if (Session["TaikhoanNguoiDung"] == null)
            {
                return RedirectToAction("DangNhap", "NguoiDung");
            }
            var list = context.YeucauBDs;
            ViewBag.YeuCauBD = list;
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, YeucauBD E_BH)
        {
            string shipName = "";
            string email = "";
            string message = "";

            if (Session["TaikhoanNguoiDung"] == null)
            {
                return RedirectToAction("DangNhap", "NguoiDung");
            }
            int solg = context.YeucauBDs.Count() + 1;
            var E_MAYC = "YC" + solg.ToString();             
            var E_TK = collection["TK"];
            var E_MOTA = collection["MOTA"];
            
            var E_TRANGTHAI = collection["TRANGTHAI"];
            var E_ANH1 = collection["ANH1"];
            var E_ANH2 = collection["ANH2"];
            var E_ANH3 = collection["ANH3"];
            var E_ANH4 = collection["ANH4"];

            if (string.IsNullOrEmpty(E_TK.ToString()) || string.IsNullOrEmpty(E_MOTA))
            {
               /* ViewData["Error"] = "Don't empty!";*/
                ModelState.AddModelError("", "Input error!");
            }
            else
            {
                E_BH.MAYC = E_MAYC.ToString();
                E_BH.TK = E_TK.ToString();
                E_BH.MOTA = E_MOTA.ToString();
                E_BH.THOIGIANYEUCAU = DateTime.Now;
                E_BH.TRANGTHAI = "Yêu cầu".ToString();
                E_BH.ANH1 = E_ANH1.ToString();
                E_BH.ANH2 = E_ANH2.ToString();
                E_BH.ANH3 = E_ANH3.ToString();
                E_BH.ANH4 = E_ANH4.ToString();
                context.YeucauBDs.Add(E_BH);
                context.SaveChanges();


                shipName = E_BH.TK.ToString();
                email = "ngyentuan252627@gmail.com";
                message = "tài khoản " + NguoiDungController.taikhus.TK.ToString() + " yêu cầu được bảo dưỡng xe máy! yêu cầu bộ phận có trách nhiệm liên quan xác nhận!";
                
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
                new MailHelper().SendMail(email, "Bảo dưỡng", content);
                new MailHelper().SendMail(toEmail, "Yêu cầu bảo dưỡng", content);
                
                return RedirectToAction("Index","Home");
            }
            return RedirectToAction("Create", "YeuCauBD");


        }

        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            string newFile = "/images/" + file.FileName;

            if (Directory.Exists(newFile) != true)
            {
                file.SaveAs(Server.MapPath("~/images/" + file.FileName));
            }
            return newFile;
        }

    }
}