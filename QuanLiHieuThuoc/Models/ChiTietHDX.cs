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
    
    public partial class ChiTietHDX
    {
        public string MaHDX { get; set; }
        public string MaThuoc { get; set; }
        public Nullable<decimal> DonGiaBan { get; set; }
        public Nullable<int> SoLuongBan { get; set; }
    
        public virtual HoaDonXuat HoaDonXuat { get; set; }
        public virtual Thuoc Thuoc { get; set; }
    }
}
