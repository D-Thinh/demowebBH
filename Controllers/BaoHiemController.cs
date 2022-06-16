
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;
using WedBH.Models;
using Commom;

namespace WedBH.Controllers
{
    public class BaoHiemController : Controller
    {
        // GET: BaoHiem
        Model1 context = new Model1();
        public ActionResult ListBaoHiem()
        {
            var all_BH = context.Baohiems;
            return View(all_BH);
        }
        public ActionResult Detail(string id)
        {
            var D_BH = context.Baohiems.Where(m => m.MABH == id).First();
            return View(D_BH);
        }

        public ActionResult Create()
        {
            var listCategory = context.Phankhoixes;
            ViewBag.ListLoai = listCategory;
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, Baohiem bh)
        {
            /*if (Session["TaiKhoan"] == null)
            {
                return RedirectToAction("DangNhap", "Admin");
            }*/
            int solg = context.Baohiems.Count() + 1;
            var E_MABH = "BH"+solg.ToString();
            //var E_MABH = collection["MABH"];
            var E_TENCHUXE = collection["TENCHUXE"];
            var E_SDT = collection["SDT"];
            var E_MAPK = collection["MAPK"];
            var E_GIOITINH = collection["GIOITINH"];
            var E_DIACHI = collection["DIACHI"];
            var E_BIENSO = collection["BIENSO"];
            var E_SOKHUNG = collection["SOKHUNG"];
            var E_SOMAY = collection["SOMAY"];
            var E_GMAIL = collection["Gmail"];
            var E_THOIHANBD = Convert.ToDateTime(collection["THOIHANBD"]);
            var E_THOIHANKT = Convert.ToDateTime(collection["THOIHANKT"]);
            var E_PHIBH = Convert.ToDecimal(collection["PHIBH"]);

            if (string.IsNullOrEmpty(E_MABH))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                bh.MABH = E_MABH.ToString();
                bh.TENCHUXE = E_TENCHUXE.ToString();
                bh.SDT = E_SDT.ToString();
                bh.MAPK = E_MAPK.ToString();
                bh.GIOITINH = E_GIOITINH.ToString();
                bh.DIACHI = E_DIACHI.ToString();
                bh.BIENSO = E_BIENSO.ToString();
                bh.SOKHUNG = E_SOKHUNG.ToString();
                bh.SOMAY = E_SOMAY.ToString();
                bh.Gmail = E_GMAIL.ToString();
                bh.PHIBH = 499000000;
                bh.THOIHANBD = E_THOIHANBD.Date;
                bh.THOIHANKT = E_THOIHANKT.Date;
                context.Baohiems.Add(bh);
                context.SaveChanges();
                return RedirectToAction("Create","BaoHiem");
                /*      
                MABH = E_MABH.ToString(),
                TENCHUXE = E_TENCHUXE.ToString(),
                SDT = E_SDT.ToString(),
                MAPK = E_MAPK.ToString(),
                GIOITINH = E_GIOITINH.ToString(),
                DIACHI = E_DIACHI.ToString(),
                BIENSO = E_BIENSO.ToString(),
                SOKHUNG = E_SOKHUNG.ToString(),
                SOMAY = E_SOMAY.ToString(),
                Gmail = E_GMAIL.ToString(),
                PHIBH = E_PHIBH,
                THOIHANBD = E_THOIHANBD.Date,
                THOIHANKT = E_THOIHANKT.Date,*/
            }
            context.Baohiems.Add(bh);
            context.SaveChanges();
            return RedirectToAction("Create","BaoHiem");
        }        
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Baohiem bh = context.Baohiems.FirstOrDefault(s => s.MABH == id);
            if (bh == null)
                return HttpNotFound();
            return View(bh);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection collection,string id)
        {
            var E_BH = context.Baohiems.First(m => m.MABH == id);
            var E_MABH = collection["MABH"];
            var E_TENCHUXE = collection["TENCHUXE"];
            var E_SDT = collection["SDT"];
            var E_MAPK = collection["MAPK"];
            var E_GIOITINH = collection["GIOITINH"];
            var E_DIACHI = collection["DIACHI"];
            var E_BIENSO = collection["BIENSO"];
            var E_SOKHUNG = collection["SOKHUNG"];
            var E_SOMAY = collection["SOMAY"];
            var E_GMAIL = collection["Gmail"];
            var E_THOIHANBD = Convert.ToDateTime(collection["THOIHANBD"]);
            var E_THOIHANKT = (collection["THOIHANKT"]);
            var E_PHIBH = Convert.ToDecimal(collection["PHIBH"]);
            E_BH.MABH = id;
            if (string.IsNullOrEmpty(E_BH.TENCHUXE))
                {
                    ViewData["Error"] = "Don't empty!";
                }
                else
                {
                    /*E_BH.TENCHUXE = E_TENCHUXE.ToString();*/
                   /* E_BH.SDT = E_SDT.ToString();                  
                    E_BH.GIOITINH = E_GIOITINH.ToString();*/
                    if (E_MAPK.Equals("Dưới 50 cc")) { E_BH.MAPK = "D50"; }   
                    if (E_MAPK.Equals("Trên 50 cc")) { E_BH.MAPK = "N50"; }
                    if (E_MAPK.Equals("Xe mô tô 3 bánh tương tự")) { E_BH.MAPK = "k50"; }
                   
                   /* E_BH.DIACHI = E_DIACHI.ToString();*/
                    E_BH.BIENSO = E_BIENSO.ToString();
                    E_BH.SOKHUNG = E_SOKHUNG.ToString();
                    E_BH.SOMAY = E_SOMAY.ToString();
                    E_BH.Gmail = E_GMAIL.ToString();                  
                   /* E_BH.THOIHANBD = E_THOIHANBD;*/
                   if(E_THOIHANKT.Equals("6 tháng")) { E_BH.THOIHANKT = E_BH.THOIHANKT.AddMonths(+6); E_BH.PHIBH = 499000; }
                   if(E_THOIHANKT.Equals("12 tháng")) { E_BH.THOIHANKT = E_BH.THOIHANKT.AddYears(+1); E_BH.PHIBH = 999000; }
                   /* E_BH.THOIHANKT = E_THOIHANKT;*/
                   
                   // UpdateModel(E_BH);
                    context.SaveChanges();
                    return RedirectToAction("ListBaoHiem");
                }
            return this.Edit(id);
        }
        //----------------------------------------- 
        public ActionResult Delete(string id)
        {
            var D_BH = context.Baohiems.First(m => m.MABH == id);
            return View(D_BH);
        }
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            var D_BH = context.Baohiems.Where(m => m.MABH == id).First();
            context.Baohiems.Remove(D_BH);
            context.SaveChanges();
            return RedirectToAction("ListBaoHiem");
        }
        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/images/" + file.FileName));
            return "/images/" + file.FileName;
        }
        public ActionResult Feedback()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Feedback(string shipName, string email, string message, string mobile, string address)
        {
            string content = System.IO.File.ReadAllText(Server.MapPath("~/client/template/Feedback1.html"));
            content = content.Replace("{{CustomerName}}", shipName);
            content = content.Replace("{{Mobile}}", mobile);
            content = content.Replace("{{Email}}", email);
            content = content.Replace("{{Address}}", address);
            content = content.Replace("{{Message}}", message);
            // Để Gmail cho phép SmtpClient kết nối đến server SMTP của nó với xác thực 
            //là tài khoản gmail của bạn, bạn cần thiết lập tài khoản email của bạn như sau:
            //Vào địa chỉ https://myaccount.google.com/security  Ở menu trái chọn mục Bảo mật, sau đó tại mục Quyền truy cập 
            //của ứng dụng kém an toàn phải ở chế độ bật
            //  Đồng thời tài khoản Gmail cũng cần bật IMAP
            //Truy cập địa chỉ https://mail.google.com/mail/#settings/fwdandpop
            /*var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();*/
            new Mail().SendMail(email, "Nhắc lịch bảo dưỡng", content);
            /*new MailHelper().SendMail(toEmail, "Nhận xét của khách", content);*/
            return Redirect("Feedback");

        }
    }
}