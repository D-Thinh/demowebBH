using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WedBH.Models;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace WedBH.Controllers
{
    public class NguoiDungController : Controller
    {
        Model1 context = new Model1();
        public static User taikhus;
        // GET: NguoiDung
        [HttpGet]
        public ActionResult DangNhap()
        {
            /*if (Session["TaikhoanNguoiDung"] != null)
            {
                MessageBox.Show("đăng nhập rồi ba ");
            }*/
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangNhap(FormCollection collection, string MK, string tk)
        {
            if (ModelState.IsValid)
            {
                var f_MK = GetMD5(MK);
                var data = context.Users.SingleOrDefault(s => s.TK.Equals(tk) && s.MK.Equals(f_MK))/*.ToList()*/;
                if (data != null)
                {
                    //add session
                    Session["TK"] = data.TK;
                    Session["MK"] = data.MK;
                    taikhus = data;
                    Session["TaikhoanNguoiDung"] = data;
                   /* ViewBag.ThongBao = "Đăng nhập thành công";*/
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.error = "Đăng nhập thất bại";
                    return RedirectToAction("DangNhap", "NguoiDung");
                }
            }
            return this.DangNhap();

        }
        public ActionResult DangXuat()
        {
            Session["TaikhoanNguoiDung"] = null;
            Session["TaiKhoan"] = null;
            taikhus = null;
            return RedirectToAction("Index", "Home");
        }

        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangNhap(FormCollection collection)
        {
            var TK = collection["TK"];
            var MK = collection["MK"];

            
                var accountNguoiDung = context.Taikhoans.FirstOrDefault(p => p.TK == TK && p.MK == MK);
                if (accountNguoiDung == null)
                {
                    ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
                    return RedirectToAction("DangNhap");
                    //return RedirectToAction("ListBaoHiem", "BaoHiem");
                }
                else
                {
                    ViewBag.Thongbao = "Đăng nhập thành công";
                    Session["TaiKhoanNguoiDung"] = accountNguoiDung;
                    return RedirectToAction("Index", "Home");
                       *//*alert('Bạn không được cập nhật chưa thanh toán');*//*
                }
            
            return View();
            *//*if (ModelState.IsValid)
            {
                var f_MK = GetMD5(MK);
                var data = context.Users.SingleOrDefault(s => s.TK.Equals(tk) && s.MK.Equals(f_MK))*//*.ToList()*//*;
                if (data !=null)
                {
                    //add session
                    *//*   Session["TK"] = data.FirstOrDefault().TK;
                       Session["MK"] = data.FirstOrDefault().MK;*//*
                    
                    ViewBag.ThongBao = "Đăng nhập thành công";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.error = "Đăng nhập thất bại";
                    return RedirectToAction("DangNhap", "NguoiDung");
                }
            }
            return this.DangNhap();*//*

        }*/
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKy(FormCollection collection, User user)
        {
            var TEN = collection["TEN"];
            var GMAIL = collection["GMAIL"];
            var SDT = collection["SDT"];
            var TK = collection["TK"];
            var MK = collection["MK"];
            var MatKhauXacNhan = collection["MatKhauXacNhan"];
            if (String.IsNullOrEmpty(MatKhauXacNhan))
            {
                ViewData["NhapMXN"] = "Phải nhập mật khẩu xác nhận!";
            }
            else
            {
                if (!MK.Equals(MatKhauXacNhan))
                {
                    ViewData["MatKhauGiongNhau"] = "Mật khẩu và mật khẩu xác nhận phải giống nhau";
                }
                if (ModelState.IsValid)
                {
                    var check = context.Users.FirstOrDefault(s => s.GMAIL == user.GMAIL);
                    if (check == null)
                    {
                        user.MK = GetMD5(user.MK);
                        context.Configuration.ValidateOnSaveEnabled = false;
                        context.Users.Add(user);
                        context.SaveChanges();
                        return RedirectToAction("DangNhap");
                    }
                    else
                    {
                        ViewBag.error = "Lỗi Gmail bị trùng";
                        ViewBag.ThongBao = "Gmail đã tồn tại";
                        return this.DangKy();
                    }
                }
            }
            return this.DangKy();
        }
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }
    }
}