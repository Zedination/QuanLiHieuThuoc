﻿using QuanLiHieuThuoc.JsonModel;
using QuanLiHieuThuoc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLiHieuThuoc.Controllers
{
    public class HoaDonNhapController : Controller
    {
        QLTHUOCEntities db = new QLTHUOCEntities();
        // GET: HoaDonNhap
        public ActionResult DanhSachHoaDonNhap()
        {
            if (Session["idUser"] != null)
            {
                var nccs = db.NCC.ToList();
                List<string> listidNcc = new List<string>();
                foreach(var item in nccs)
                {
                    listidNcc.Add(item.MaNCC);
                }
                ViewBag.listIdNCC = listidNcc;
                var nvs = db.NhanVien.ToList();
                List<String> listmavn = new List<string>();
                foreach(var item in nvs)
                {
                    listmavn.Add(item.MaNV);
                }
                ViewBag.listmanv = listmavn;
                var thuocs = db.Thuoc.ToList();
                List<string> listmathuoc = new List<string>();
                foreach(var item in thuocs)
                {
                    listmathuoc.Add(item.MaThuoc);
                }
                ViewBag.listmathuoc = listmathuoc;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }
        [HttpGet]
        public ActionResult JsonHoaDonNhap()
        {
            try
                    String[] hdns = { MaHDN,MaNV,NgayNhap,MaNCC.Trim() };
        }
        [HttpGet]
        public ActionResult JsonCTHDN()
        {
            try
        }
        public ActionResult CreateHoaDonNhap(HoaDonNhapJson temp)
        {
            try
        }
        [HttpPost]
                db.Entry(temp).State = EntityState.Modified;
        [HttpPost]
                    {
                        db.Entry(item).State = EntityState.Deleted;
                    }
        [HttpPost]
        public ActionResult CreateCTHDN(CTHDNJson ct)
        {
            try
        }
        [HttpPost]
        public ActionResult EditCTHDN(CTHDNJson ct)
        {
            try
            {
                
                ChiTietHDN temp = db.ChiTietHDN.Where(n => (n.MaHDN == ct.MaHDN) && (n.MaThuoc == ct.MaThuoc)).SingleOrDefault();
                var soLuongCu = temp.SoluongNhap;
                temp.DonGiaNhap = Convert.ToDecimal(ct.DonGiaNhap); temp.SoluongNhap = Convert.ToInt32(ct.SoluongNhap);
                db.Entry(temp).State = EntityState.Modified;
                var soLuongMoi = temp.SoluongNhap - soLuongCu;
                Thuoc data = db.Thuoc.Where(n => n.MaThuoc == temp.MaThuoc).SingleOrDefault();
                data.SoLuong = data.SoLuong + soLuongMoi;
                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, message = "Sửa chi tiết hóa đơn nhập thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { success = false, mesage = "Sửa không thành công" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult DeleteCTHDN(CTHDNJson ct)
        {
            try
            {

                var delete = db.ChiTietHDN.Where(n => (n.MaHDN == ct.MaHDN) && (n.MaThuoc == ct.MaThuoc)).SingleOrDefault();
                var count = delete.SoluongNhap;
                db.Entry(delete).State = EntityState.Deleted;
                var data = db.Thuoc.Where(n => n.MaThuoc == delete.MaThuoc).SingleOrDefault();
                data.SoLuong = data.SoLuong - count;
                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { mes = "Xóa thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Json(new { mes = "Xóa không thành công: "+e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ExportToExcel()
        {
            var gv = new GridView();
            var data = db.HoaDonNhap.ToList();
            gv.DataSource = data;
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=DemoExcel.xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
            gv.RenderControl(objHtmlTextWriter);
            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();
            return RedirectToAction("DanhSachHoaDonNhap");
        }
    }
}