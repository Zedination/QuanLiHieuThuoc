//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLiHieuThuoc.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChiTietHDN
    {
        public string MaHDN { get; set; }
        public string MaThuoc { get; set; }
        public Nullable<decimal> DonGiaNhap { get; set; }
        public Nullable<int> SoluongNhap { get; set; }
    
        public virtual HoaDonNhap HoaDonNhap { get; set; }
        public virtual Thuoc Thuoc { get; set; }
    }
}
