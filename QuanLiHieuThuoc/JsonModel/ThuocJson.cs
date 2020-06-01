using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLiHieuThuoc.JsonModel
{
    public class ThuocJson
    {
        public String MaThuoc { get; set; }
        public String TenThuoc { get; set; }
        public String MaLoaiThuoc { get; set; }
        public String MaNCC { get; set; }
        public String CongDung { get; set; }
        public String HanSuDung { get; set; }
        public String Donvitinh { get; set; }
        public int SoLuong { get; set; }
        public String DonGiaNhap { get; set; }
    }
}