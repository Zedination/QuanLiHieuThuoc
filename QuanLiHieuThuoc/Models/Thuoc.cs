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
    
    public partial class Thuoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Thuoc()
        {
            this.ChiTietHDN = new HashSet<ChiTietHDN>();
            this.ChiTietHDX = new HashSet<ChiTietHDX>();
        }
    
        public string MaThuoc { get; set; }
        public string TenThuoc { get; set; }
        public string MaLoaiThuoc { get; set; }
        public string MaNCC { get; set; }
        public string CongDung { get; set; }
        public Nullable<System.DateTime> HanSuDung { get; set; }
        public string Donvitinh { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<decimal> DonGiaNhap { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHDN> ChiTietHDN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHDX> ChiTietHDX { get; set; }
        public virtual LoaiThuoc LoaiThuoc { get; set; }
        public virtual NCC NCC { get; set; }
    }
}
