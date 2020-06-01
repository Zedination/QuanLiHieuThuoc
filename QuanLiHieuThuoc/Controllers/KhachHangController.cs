using System;using System.Collections.Generic;using System.Data.Entity;using System.IO;
using System.Linq;using System.Net;using System.Web;using System.Web.Mvc;using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLiHieuThuoc.JsonModel;using QuanLiHieuThuoc.Models;namespace QuanLiHieuThuoc.Controllers{    public class KhachHangController : Controller    {
        // GET: KhachHang
        QLTHUOCEntities db = new QLTHUOCEntities();
        // GET: NhanVien
        public ActionResult DanhSachKhachHang()        {            if (Session["idUser"] != null)            {                return View();            }            else            {                return RedirectToAction("Login", "Login");            }        }        [HttpGet]        public ActionResult JsonKhachHang()        {            try            {                var data = db.KhachHang.ToList();                List<Array> temp = new List<Array>();                data.ForEach(n =>                {                    String MaKH = n.MaKH;                    String TenKH = n.TenKH;                    String DiaChi = n.DiaChi;                    String DienThoai = n.DienThoai;                    String Email = n.Email;
                    String[] khs = { MaKH, TenKH, DiaChi, DienThoai, Email };                    temp.Add(khs);                });                return Json(new { data = temp }, JsonRequestBehavior.AllowGet);            }            catch (Exception ex)            {                Response.StatusCode = (int)HttpStatusCode.BadRequest;                return Json(ex.Message, JsonRequestBehavior.AllowGet);            }        }        [HttpPost]        public ActionResult CreateKhachHang(KhachHangJson kh)        {            try            {                KhachHang newKH = new KhachHang                {                    MaKH = kh.MaKH,                    TenKH = kh.TenKH,                    DiaChi = kh.DiaChi,                    DienThoai = kh.DienThoai,
                    Email = kh.Email,                };                db.KhachHang.Add(newKH);                db.SaveChanges();                return Json(new { code = 200, mes = "Thêm khách hàng thành công" }, JsonRequestBehavior.AllowGet);            }            catch (Exception e)            {                return Json(new { code = 500, mes = e.Message }, JsonRequestBehavior.AllowGet);            }        }        [HttpPost]        public ActionResult EditKhachHang(KhachHangJson kh)        {            try            {                KhachHang temp = db.KhachHang.Where(n => n.MaKH == kh.MaKH).SingleOrDefault();                temp.TenKH = kh.TenKH; temp.DiaChi = kh.DiaChi; temp.DienThoai = kh.DienThoai;                temp.Email = kh.Email;
                db.Entry(temp).State = EntityState.Modified;                db.SaveChanges();                return Json(new { success = true, message = "Sửa thành công" }, JsonRequestBehavior.AllowGet);            }            catch (Exception e)            {                return Json(new { success = false, message = "Sửa không thành công, lỗi: " + e.Message }, JsonRequestBehavior.AllowGet);            }        }        [HttpPost]        public ActionResult DeleteKhachHang(KhachHangJson temp)        {            try            {                var hdx = db.HoaDonXuat.Where(n => n.MaKH == temp.MaKH);                if (hdx != null)                {                    foreach (var a in hdx)                    {                        var cthdx = db.ChiTietHDX.Where(m => m.MaHDX == a.MaHDX);                        if (cthdx != null)                        {                            foreach (var item in cthdx)                            {                                db.Entry(item).State = EntityState.Deleted;                            }                        }                    }                    foreach (var item in hdx)                    {                        db.Entry(item).State = EntityState.Deleted;                    }                }                KhachHang nv = db.KhachHang.Where(n => n.MaKH == temp.MaKH).SingleOrDefault();                db.Entry(nv).State = EntityState.Deleted;                db.SaveChanges();                return Json(new { success = true, message = "Xóa khách hàng thành công" }, JsonRequestBehavior.AllowGet);            }            catch (Exception e)            {                return Json(new { success = false, message = "Xóa không thành công, lỗi: " + e.Message }, JsonRequestBehavior.AllowGet);            }        }        public ActionResult ExportToExcel()
        {
            var gv = new GridView();
            var data = db.KhachHang.ToList();
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
            return View("DanhSachKhachHang");
        }    }}