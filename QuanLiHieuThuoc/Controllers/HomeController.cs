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
        
    }
    
}