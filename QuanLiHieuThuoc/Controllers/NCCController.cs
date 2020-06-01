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
    public class NCCController : Controller
    {
        // GET: NCC
        QLTHUOCEntities db = new QLTHUOCEntities();
        // GET: NhanVien
        public ActionResult DanhSachNCC()
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
        public ActionResult JsonNCC()
        {
            try
            {
                var data = db.NCC.ToList();
                List<Array> temp = new List<Array>();
                data.ForEach(n =>
                {
                    String MaNCC = n.MaNCC;
                    String TenNCC = n.TenNCC;
                    String DiaChi = n.Diachi;
                    String DienThoai = n.Dienthoai;
                    String Email = n.Email;
             
                    String[] ncc = { MaNCC, TenNCC, DiaChi, DienThoai, Email };
                    temp.Add(ncc);
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
        public ActionResult CreateNCC(NCCJson ncc)
        {
            try
            {
                NCC newNCC = new NCC
                {
                    MaNCC = ncc.MaNCC,
                    TenNCC = ncc.TenNCC,        
                    Diachi = ncc.Diachi,
                    Dienthoai = ncc.Dienthoai,
                    Email = ncc.Email,
                    
                };
                db.NCC.Add(newNCC);
                db.SaveChanges();
                return Json(new { code = 200, mes = "Thêm NCC thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 500, mes = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult EditNCC(NCCJson ncc)
        {
            try
            {
                NCC temp = db.NCC.Where(n => n.MaNCC == ncc.MaNCC).SingleOrDefault();
                temp.TenNCC = ncc.TenNCC; 
                
                temp.Diachi = ncc.Diachi; 
                temp.Dienthoai = ncc.Dienthoai;
                temp.Email = ncc.Email;
                db.Entry(temp).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, message = "Sửa thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = "Sửa không thành công, lỗi: " + e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DeleteNCC(NCCJson temp)
        {
            try
            {
                var thuoc = db.Thuoc.Where(n => n.MaNCC == temp.MaNCC);
                if (thuoc != null)
                {
                    foreach (var a in thuoc)
                    {
                        var cthdn = db.ChiTietHDN.Where(m => m.MaThuoc == a.MaThuoc);
                        if (cthdn != null)
                        {
                            foreach (var item in cthdn)
                            {
                                db.Entry(item).State = EntityState.Deleted;
                            }

                        }
                    }
                    foreach (var a in thuoc)
                    {
                        var cthdx = db.ChiTietHDX.Where(m => m.MaThuoc == a.MaThuoc);
                        if (cthdx != null)
                        {
                            foreach (var item in cthdx)
                            {
                                db.Entry(item).State = EntityState.Deleted;
                            }

                        }
                    }

                    foreach (var item in thuoc)
                    {
                        db.Entry(item).State = EntityState.Deleted;
                    }
                }

                NCC ncc = db.NCC.Where(n => n.MaNCC == temp.MaNCC).SingleOrDefault();
                db.Entry(ncc).State = EntityState.Deleted;
                db.SaveChanges();
                return Json(new { success = true, message = "Xóa NCC thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = "Xóa không thành công, lỗi: " + e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ExportToExcel()
        {
            var gv = new GridView();
            var data = db.NCC.ToList();
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
            return RedirectToAction("DanhSachNCC");
        }
    }
}