using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WedBH.Models;
namespace WedBH.Controllers
{
    public class AdminController : Controller
    {
        static String tendn;
        public Taikhoan tkadmin;
        Model1 context = new Model1();
        // GET: Admin
        public ActionResult DangNhap()
        {

            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(FormCollection collection)
        {
            var TK = collection["TK"];
            var MK = collection["MK"];

            if (String.IsNullOrEmpty(TK))
            {
                ViewData["Loi1"] = "Phải nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(MK))
            {
                ViewData["Loi2"] = "Phải nhập tên mật khẩu";
            }
            else
            {
                var accountAdmin = context.Taikhoans.FirstOrDefault(p => p.TK == TK && p.MK == MK);
                if (accountAdmin == null)
                {
                    ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
                    return RedirectToAction("DangNhap");
                    tkadmin = accountAdmin;
                    //return RedirectToAction("ListBaoHiem", "BaoHiem");
                }
                else
                {

                    Session["TaiKhoan"] = accountAdmin;
                    tendn = accountAdmin.TEN;
                    return RedirectToAction("ListBaoHiem", "BaoHiem");

                }    
               
            }
            return View();
        }
        public ActionResult DangXuat()
        {
            Session["TaiKhoan"] = null;
            tkadmin = null;
            return RedirectToAction("DangNhap", "TaiKhoan");
        }
        public ActionResult Chitietbaohiem(String id)
        {

            Baohiem s = context.Baohiems.SingleOrDefault(p => p.MABH.Equals(id));
            ViewBag.MABH = s.MABH;
            if (s == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(s);
        }

        public ActionResult Edit(string id)
        {
            if (Session["TaiKhoan"] == null)
            {
                return RedirectToAction("DangNhap", "Admin");
            }
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
        public ActionResult Edit(string id, FormCollection collection)
        {
            if (Session["TaiKhoan"] == null)
            {
                return RedirectToAction("DangNhap", "Admin");
            }
            var E_BH = context.Baohiems.First(m => m.MABH == id);
            var E_MABH = collection["MABH"];
            var E_TENCHUXE = collection["TENCHUXE"];
            var E_hinh = collection["hinh"];
            var E_SDT = collection["SDT"];
            var E_MAPK = collection["MAPK"];
            var E_GIOITINH = collection["GIOITINH"];
            var E_DIACHI = collection["DIACHI"];
            var E_BIENSO = collection["BIENSO"];
            var E_SOKHUNG = collection["SOKHUNG"];
            var E_SOMAY = collection["SOMAY"];
            var E_THOIHANBD = Convert.ToDateTime(collection["THOIHANBD"]);
            var E_THOIHANKT = Convert.ToDateTime(collection["THOIHANKT"]);
            var E_PHIBH = Convert.ToDecimal(collection["PHIBH"]);
            E_BH.MABH = id;
            if (string.IsNullOrEmpty(E_BH.MABH))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                E_BH.MABH = E_MABH.ToString();
                E_BH.TENCHUXE = E_TENCHUXE.ToString();
                E_BH.SDT = E_SDT.ToString();
                E_BH.MAPK = E_MAPK.ToString();
                E_BH.GIOITINH = E_GIOITINH.ToString();
                E_BH.DIACHI = E_DIACHI.ToString();
                E_BH.BIENSO = E_BIENSO.ToString();
                E_BH.SOKHUNG = E_SOKHUNG.ToString();
                E_BH.SOMAY = E_SOMAY.ToString();
                E_BH.PHIBH = E_PHIBH;
                E_BH.THOIHANBD = E_THOIHANBD;
                E_BH.THOIHANKT = E_THOIHANKT;
                UpdateModel(E_BH);
                context.SaveChanges();
                return RedirectToAction("ListBaoHiem");
            }
            return this.Edit(id);
        }
    }
}