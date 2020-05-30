using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLiHieuThuoc.JsonModel;
using QuanLiHieuThuoc.Models;

namespace QuanLiHieuThuoc.Controllers
{
    public class HomeController : Controller
    {
        QLTHUOCEntities db = new QLTHUOCEntities();
        // GET: Home
        public ActionResult Index()
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
        public ActionResult DanhSachNhanVien()
        {
            return View();
        }
        [HttpGet]
        public ActionResult JsonNhanVien()
        {
            try
            {
                var data = db.NhanVien.Select(n => new NhanVienJson
                {
                    MaNV = n.MaNV,
                    HoTen = n.HoTen,
                    ChucVu = n.ChucVu,
                    GioiTinh = n.GioiTinh,
                    Ngaysinh = n.Ngaysinh.ToString(),
                    Diachi = n.Diachi,
                    Email = n.Email,
                    DienThoai = n.DienThoai,
                    NgayLV = n.NgayLV.ToString(),
                }).ToList();
                ListNhanVienJson list = new ListNhanVienJson();
                list.data = data;
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message,JsonRequestBehavior.AllowGet);
            }

        }
        
    }
    
}