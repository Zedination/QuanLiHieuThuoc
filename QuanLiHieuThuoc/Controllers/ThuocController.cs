using QuanLiHieuThuoc.JsonModel;
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
    
    public class ThuocController : Controller
    {
        QLTHUOCEntities db = new QLTHUOCEntities();
        // GET: Thuoc
        public ActionResult DanhSachThuoc()
        {
            if (Session["idUser"] != null)
            {
                var ncc = db.NCC.ToList();
                List<String> listncc = new List<string>();
                foreach (var item in ncc)
                {
                    listncc.Add(item.MaNCC);
                }
                ViewBag.listncc = listncc;
                var loaithuoc = db.LoaiThuoc.ToList();
                List<String> listloaithuoc = new List<string>();
                foreach (var item in loaithuoc)
                {
                    listloaithuoc.Add(item.MaLoaiThuoc);
                }
                ViewBag.listloaithuoc = listloaithuoc;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }
        [HttpGet]
        public ActionResult JsonThuoc()
        {
            try
            {
                var data = db.Thuoc.ToList();
                List<Array> temp = new List<Array>();
                data.ForEach(n =>
                {
                    String MaThuoc = n.MaThuoc;
                    String TenThuoc = n.TenThuoc;
                    String MaLoaiThuoc = n.MaLoaiThuoc;
                    String MaNCC = n.MaNCC;
                    String CongDung = n.CongDung;
                    //String Ngaysinh = n.Ngaysinh.ToString();
                    DateTime temp1 = Convert.ToDateTime(n.HanSuDung);
                    String HanSuDung = temp1.ToString("yyyy-MM-dd");
                    String Donvitinh = n.Donvitinh;
                    int? SoLuong = n.SoLuong;
                    Decimal? DonGiaNhap = n.DonGiaNhap;
                    String[] nvs = { MaThuoc, TenThuoc, MaLoaiThuoc, MaNCC, CongDung, HanSuDung, Donvitinh, SoLuong.ToString(),DonGiaNhap.ToString()};
                    temp.Add(nvs);
                });
                return Json(new { data = temp }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult CreateThuoc(ThuocJson nv)
        {
            try
            {
                Thuoc newThuoc = new Thuoc
                {
                    MaThuoc = nv.MaThuoc,
                    TenThuoc = nv.TenThuoc,
                    MaLoaiThuoc = nv.MaLoaiThuoc,
                    MaNCC = nv.MaNCC,
                    CongDung = nv.CongDung,
                    HanSuDung = Convert.ToDateTime(nv.HanSuDung),
                    Donvitinh = nv.Donvitinh,
                    SoLuong = nv.SoLuong,
                    DonGiaNhap = Convert.ToDecimal(nv.DonGiaNhap),
                };
                db.Thuoc.Add(newThuoc);
                db.SaveChanges();
                return Json(new { code = 200, mes = "Thêm thuốc thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 500, mes = nv.TenThuoc }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult EditThuoc(ThuocJson nv)
        {
            try
            {
                Thuoc temp = db.Thuoc.Where(n => n.MaThuoc == nv.MaThuoc).SingleOrDefault();
                temp.TenThuoc = nv.TenThuoc; temp.MaLoaiThuoc = nv.MaLoaiThuoc; temp.MaNCC = nv.MaNCC;
                temp.CongDung = nv.CongDung; temp.HanSuDung = Convert.ToDateTime(nv.HanSuDung);
                temp.Donvitinh = nv.Donvitinh; temp.SoLuong = nv.SoLuong;
                temp.DonGiaNhap = Convert.ToDecimal(nv.DonGiaNhap);
                db.Entry(temp).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, message = "Sửa thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = "Sửa không thành công, lỗi: " + e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DeleteThuoc(ThuocJson temp)
        {
            try
            {
                var cthdn = db.ChiTietHDN.Where(n => n.MaThuoc == temp.MaThuoc);
                if (cthdn != null)
                {
                    foreach (var item in cthdn)
                    {
                        db.Entry(item).State = EntityState.Deleted;
                    }
                }
                var cthdx = db.ChiTietHDX.Where(n => n.MaThuoc == temp.MaThuoc);
                if (cthdx != null)
                {
                    foreach (var item in cthdx)
                    {
                        db.Entry(item).State = EntityState.Deleted;
                    }
                }
                Thuoc t = db.Thuoc.Where(n => n.MaThuoc == temp.MaThuoc).SingleOrDefault();
                db.Entry(t).State = EntityState.Deleted;
                db.SaveChanges();
                return Json(new { success = true, message = "Xóa nhân viên thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = "Xóa không thành công, lỗi: " + e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult ExportToExcel()
        {
            var gv = new GridView();
            var data = db.Thuoc.ToList();
            gv.DataSource = data;
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=DemoExcel.xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "utf-8";
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
            gv.RenderControl(objHtmlTextWriter);
            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();
            return View("DanhSachThuoc");
        }
    }
}