using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLiHieuThuoc.JsonModel;
using QuanLiHieuThuoc.Models;
namespace QuanLiHieuThuoc.Controllers
{
    public class NhanVienController : Controller
    {
        QLTHUOCEntities db = new QLTHUOCEntities();
        // GET: NhanVien
        public ActionResult DanhSachNhanVien()
        {
            if (Session["idUser"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }
        [HttpGet]
        public ActionResult JsonNhanVien()
        {
            try
            {
                var data = db.NhanVien.ToList();
                List<Array> temp = new List<Array>();
                data.ForEach(n =>
                {
                    String MaNV = n.MaNV;
                    String HoTen = n.HoTen;
                    String ChucVu = n.ChucVu;
                    String GioiTinh = n.GioiTinh;
                    //String Ngaysinh = n.Ngaysinh.ToString();
                    DateTime temp1 = Convert.ToDateTime(n.Ngaysinh);
                    String Ngaysinh = temp1.ToString("yyyy-MM-dd");
                    String Diachi = n.Diachi;
                    String Email = n.Email;
                    String DienThoai = n.DienThoai;
                    //String NgayLV = n.NgayLV.ToString();
                    DateTime temp2 = Convert.ToDateTime(n.NgayLV);
                    String NgayLV = temp2.ToString("yyyy-MM-dd");
                    String[] nvs = { MaNV, HoTen, ChucVu, GioiTinh, Ngaysinh, Diachi, Email, DienThoai, NgayLV };
                    temp.Add(nvs);
                });
                return Json(new { data = temp },JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult CreateNhanVien(NhanVienJson nv)
        {
            try
            {
                NhanVien newNV = new NhanVien
                {
                    MaNV = nv.MaNV,
                    HoTen = nv.HoTen,
                    ChucVu = nv.ChucVu,
                    GioiTinh = nv.GioiTinh,
                    Ngaysinh = Convert.ToDateTime(nv.Ngaysinh),
                    Diachi = nv.Diachi,
                    DienThoai = nv.DienThoai,
                    Email = nv.Email,
                    NgayLV = Convert.ToDateTime(nv.NgayLV)
                };
                db.NhanVien.Add(newNV);
                db.SaveChanges();
                return Json(new { code = 200, mes = "Thêm nhân viên thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Json(new { code = 500, mes = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult EditNhanVien(NhanVienJson nv)
        {
            try
            {
                NhanVien temp = db.NhanVien.Where(n => n.MaNV == nv.MaNV).SingleOrDefault();
                temp.HoTen = nv.HoTen; temp.ChucVu = nv.ChucVu; temp.GioiTinh = nv.GioiTinh;
                temp.Ngaysinh = Convert.ToDateTime(nv.Ngaysinh);
                temp.Diachi = nv.Diachi; temp.Email = nv.Email;
                temp.DienThoai = nv.DienThoai;
                temp.NgayLV = Convert.ToDateTime(nv.NgayLV);
                db.Entry(temp).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, message = "Sửa thành công" }, JsonRequestBehavior.AllowGet);
            } catch (Exception e)
            {
                return Json(new { success = false, message = "Sửa không thành công, lỗi: "+e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DeleteNhanVien(NhanVienJson temp)
        {
            try
            {
                var hdn = db.HoaDonNhap.Where(n => n.MaNV == temp.MaNV);
                if (hdn != null)
                {
                    foreach(var a in hdn)
                    {
                        var cthdn = db.ChiTietHDN.Where(m => m.MaHDN == a.MaHDN);
                        if (cthdn != null)
                        {
                            foreach(var item in cthdn)
                            {
                                db.Entry(item).State = EntityState.Deleted;
                            }

                        }
                    }
                    foreach(var item in hdn)
                    {
                        db.Entry(item).State = EntityState.Deleted;
                    }
                }
                NhanVien nv = db.NhanVien.Where(n => n.MaNV == temp.MaNV).SingleOrDefault();
                db.Entry(nv).State = EntityState.Deleted;
                db.SaveChanges();
                return Json(new { success = true, message = "Xóa nhân viên thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Json(new { success = false, message = "Xóa không thành công, lỗi: " + e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        
    }
}