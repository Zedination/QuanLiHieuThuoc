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
    public class HoaDonXuatController : Controller
    {
        // GET: HoaDonXuat
        QLTHUOCEntities db = new QLTHUOCEntities();
        // GET: NhanVien
        public ActionResult DanhSachHoaDonXuat()
        {
            if (Session["idUser"] != null)
            {
                var nccs = db.NhanVien.ToList();
                List<string> listidNv = new List<string>();
                foreach (var item in nccs)
                {
                    listidNv.Add(item.MaNV);
                }
                ViewBag.listIdNV = listidNv;
                var nvs = db.KhachHang.ToList();
                List<String> listmakh = new List<string>();
                foreach (var item in nvs)
                {
                    listmakh.Add(item.MaKH);
                }
                ViewBag.listmakh = listmakh;
                var thuocs = db.Thuoc.ToList();
                List<string> listmathuoc = new List<string>();
                foreach (var item in thuocs)
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
        public ActionResult JsonHoaDonXuat()
        {
            try
            {
                var data = db.HoaDonXuat.ToList();
                List<Array> temp = new List<Array>();
                data.ForEach(n =>
                {
                    String MaHDX = n.MaHDX;
                    String MaNV = n.MaNV;
                    String MaKH = n.MaKH;
                    DateTime temp1 = Convert.ToDateTime(n.NgayXuat);
                    String NgayXuat = temp1.ToString("yyyy-MM-dd");
                    String BacSi = n.BacSi;
                    String DVCT = n.DVCT;                  
                    String[] hdxs = { MaHDX, MaNV, MaKH, NgayXuat, BacSi, DVCT };
                    temp.Add(hdxs);
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
        public ActionResult CreateHoaDonXuat(HoaDonXuatJson hdx)
        {
            try
            {
                HoaDonXuat newHDX = new HoaDonXuat
                {
                    MaHDX = hdx.MaHDX,
                    MaNV = hdx.MaNV,
                    MaKH = hdx.MaKH,
                    NgayXuat = Convert.ToDateTime(hdx.NgayXuat),
                    BacSi = hdx.BacSi,
                    DVCT = hdx.DVCT,                   
                };
                db.HoaDonXuat.Add(newHDX);
                db.SaveChanges();
                return Json(new { code = 200, mes = "Thêm hóa đơn xuất thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 500, mes = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult EditHoaDonXuat(HoaDonXuatJson hdx)
        {
            try
            {
                HoaDonXuat temp = db.HoaDonXuat.Where(n => n.MaHDX == hdx.MaHDX).SingleOrDefault();
                temp.MaNV = hdx.MaNV; temp.MaKH = hdx.MaKH;
                temp.NgayXuat = Convert.ToDateTime(hdx.NgayXuat);
                temp.BacSi = hdx.BacSi; temp.DVCT = hdx.DVCT;               
                db.Entry(temp).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, message = "Sửa thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = "Sửa không thành công, lỗi: " + e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DeleteHoaDonXuat(HoaDonXuatJson temp)
        {
            try
            {
                var cthdx = db.ChiTietHDX.Where(n => n.MaHDX == temp.MaHDX);
                if (cthdx != null)
                {
                    foreach (var a in cthdx)
                    {
                        db.Entry(a).State = EntityState.Deleted;
                    }    
                    
                }
                var nv = db.HoaDonXuat.Where(n => n.MaHDX == temp.MaHDX).SingleOrDefault();
                db.Entry(nv).State = EntityState.Deleted;
                db.SaveChanges();
                return Json(new { success = true, message = "Xóa hóa đơn xuất thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = "Xóa không thành công, lỗi: " + temp.MaHDX }, JsonRequestBehavior.AllowGet);
            }
        }
        //chi tiết hdx
        [HttpGet]
        public ActionResult JsonCTHDX()
        {
            try
            {
                var data = db.ChiTietHDX.ToList();
                List<Array> temp = new List<Array>();
                data.ForEach(n =>
                {
                    String MaHDX = n.MaHDX;
                    String MaThuoc = n.MaThuoc;
                    String DonGiaBan = Convert.ToString(n.DonGiaBan);
                    int? SoLuongBan = n.SoLuongBan;
                    String[] cthdn = { MaHDX, MaThuoc, DonGiaBan, SoLuongBan.ToString() };
                    temp.Add(cthdn);
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
        public ActionResult CreateCTHDX(CTHDXJson ct)
        {
            try
            {
                ChiTietHDX newHDX = new ChiTietHDX
                {
                    MaHDX = ct.MaHDX,
                    MaThuoc = ct.MaThuoc,
                    DonGiaBan = Convert.ToDecimal(ct.DonGiaBan),
                    SoLuongBan = Convert.ToInt32(ct.SoLuongBan)
                };
                db.ChiTietHDX.Add(newHDX);
                var count = newHDX.SoLuongBan;
                var data = db.Thuoc.Where(n => n.MaThuoc == ct.MaThuoc).SingleOrDefault();
                data.SoLuong = data.SoLuong - count;
                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { code = 200, mes = "Thêm chi tiết Hóa Đơn xuất thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 500, mes = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult EditCTHDX(CTHDXJson ct)
        {
            try
            {
                ChiTietHDX temp = db.ChiTietHDX.Where(n => (n.MaHDX == ct.MaHDX) && (n.MaThuoc == ct.MaThuoc)).SingleOrDefault();
                var oldcount = temp.SoLuongBan;
                temp.DonGiaBan = Convert.ToDecimal(ct.DonGiaBan); temp.SoLuongBan = Convert.ToInt32(ct.SoLuongBan);
                var count = oldcount - temp.SoLuongBan;
                db.Entry(temp).State = EntityState.Modified;
                var data = db.Thuoc.Where(n => n.MaThuoc == ct.MaThuoc).SingleOrDefault();
                data.SoLuong = data.SoLuong - count;
                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, message = "Sửa chi tiết hóa đơn xuất thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { success = false, mesage = "Sửa không thành công" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult DeleteCTHDX(CTHDXJson ct)
        {
            try
            {
                var delete = db.ChiTietHDX.Where(n => (n.MaHDX == ct.MaHDX) && (n.MaThuoc == ct.MaThuoc)).SingleOrDefault();
                var count = delete.SoLuongBan;
                db.Entry(delete).State = EntityState.Deleted;
                var data = db.Thuoc.Where(n => n.MaThuoc == ct.MaThuoc).SingleOrDefault();
                data.SoLuong = data.SoLuong + count;
                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { mes = "Xóa thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { mes = "Xóa không thành công: " + e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult ExportToExcel()
        {
            var gv = new GridView();
            var data = db.HoaDonXuat.ToList();
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
            return RedirectToAction("DanhSachHoaDonXuat");
        }
    }
}