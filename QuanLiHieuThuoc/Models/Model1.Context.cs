﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class QLTHUOCEntities : DbContext
    {
        public QLTHUOCEntities()
            : base("name=QLTHUOCEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ChiTietHDN> ChiTietHDN { get; set; }
        public virtual DbSet<ChiTietHDX> ChiTietHDX { get; set; }
        public virtual DbSet<HoaDonNhap> HoaDonNhap { get; set; }
        public virtual DbSet<HoaDonXuat> HoaDonXuat { get; set; }
        public virtual DbSet<KhachHang> KhachHang { get; set; }
        public virtual DbSet<LoaiThuoc> LoaiThuoc { get; set; }
        public virtual DbSet<NCC> NCC { get; set; }
        public virtual DbSet<NhanVien> NhanVien { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Thuoc> Thuoc { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<v_3> v_3 { get; set; }
        public virtual DbSet<v_7> v_7 { get; set; }
        public virtual DbSet<vv_1> vv_1 { get; set; }
    
        [DbFunction("QLTHUOCEntities", "fn_2")]
        public virtual IQueryable<fn_2_Result> fn_2(string gt)
        {
            var gtParameter = gt != null ?
                new ObjectParameter("gt", gt) :
                new ObjectParameter("gt", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<fn_2_Result>("[QLTHUOCEntities].[fn_2](@gt)", gtParameter);
        }
    
        public virtual ObjectResult<sp_1_Result> sp_1()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_1_Result>("sp_1");
        }
    
        public virtual int sp_10(string tenthuoc, string maloai, string mancc, string congdung, Nullable<System.DateTime> hsd, string dvt, string mathuoc)
        {
            var tenthuocParameter = tenthuoc != null ?
                new ObjectParameter("tenthuoc", tenthuoc) :
                new ObjectParameter("tenthuoc", typeof(string));
    
            var maloaiParameter = maloai != null ?
                new ObjectParameter("maloai", maloai) :
                new ObjectParameter("maloai", typeof(string));
    
            var manccParameter = mancc != null ?
                new ObjectParameter("mancc", mancc) :
                new ObjectParameter("mancc", typeof(string));
    
            var congdungParameter = congdung != null ?
                new ObjectParameter("congdung", congdung) :
                new ObjectParameter("congdung", typeof(string));
    
            var hsdParameter = hsd.HasValue ?
                new ObjectParameter("hsd", hsd) :
                new ObjectParameter("hsd", typeof(System.DateTime));
    
            var dvtParameter = dvt != null ?
                new ObjectParameter("dvt", dvt) :
                new ObjectParameter("dvt", typeof(string));
    
            var mathuocParameter = mathuoc != null ?
                new ObjectParameter("mathuoc", mathuoc) :
                new ObjectParameter("mathuoc", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_10", tenthuocParameter, maloaiParameter, manccParameter, congdungParameter, hsdParameter, dvtParameter, mathuocParameter);
        }
    
        public virtual int sp_11(string mathuoc)
        {
            var mathuocParameter = mathuoc != null ?
                new ObjectParameter("mathuoc", mathuoc) :
                new ObjectParameter("mathuoc", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_11", mathuocParameter);
        }
    
        public virtual ObjectResult<sp_2_Result> sp_2(Nullable<System.DateTime> ngaynhap)
        {
            var ngaynhapParameter = ngaynhap.HasValue ?
                new ObjectParameter("ngaynhap", ngaynhap) :
                new ObjectParameter("ngaynhap", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_2_Result>("sp_2", ngaynhapParameter);
        }
    
        public virtual int sp_3(Nullable<int> thang, ObjectParameter doanhThu)
        {
            var thangParameter = thang.HasValue ?
                new ObjectParameter("thang", thang) :
                new ObjectParameter("thang", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_3", thangParameter, doanhThu);
        }
    
        public virtual int sp_4(string mkh, Nullable<int> nam, ObjectParameter tien)
        {
            var mkhParameter = mkh != null ?
                new ObjectParameter("mkh", mkh) :
                new ObjectParameter("mkh", typeof(string));
    
            var namParameter = nam.HasValue ?
                new ObjectParameter("nam", nam) :
                new ObjectParameter("nam", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_4", mkhParameter, namParameter, tien);
        }
    
        public virtual ObjectResult<sp_5_Result> sp_5(string mkh)
        {
            var mkhParameter = mkh != null ?
                new ObjectParameter("mkh", mkh) :
                new ObjectParameter("mkh", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_5_Result>("sp_5", mkhParameter);
        }
    
        public virtual int sp_6(string mncc, ObjectParameter tongtien)
        {
            var mnccParameter = mncc != null ?
                new ObjectParameter("mncc", mncc) :
                new ObjectParameter("mncc", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_6", mnccParameter, tongtien);
        }
    
        public virtual ObjectResult<sp_7_Result> sp_7()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_7_Result>("sp_7");
        }
    
        public virtual ObjectResult<sp_8_Result> sp_8(string getmathuoc, string gettenthuoc, string start, string end)
        {
            var getmathuocParameter = getmathuoc != null ?
                new ObjectParameter("getmathuoc", getmathuoc) :
                new ObjectParameter("getmathuoc", typeof(string));
    
            var gettenthuocParameter = gettenthuoc != null ?
                new ObjectParameter("gettenthuoc", gettenthuoc) :
                new ObjectParameter("gettenthuoc", typeof(string));
    
            var startParameter = start != null ?
                new ObjectParameter("start", start) :
                new ObjectParameter("start", typeof(string));
    
            var endParameter = end != null ?
                new ObjectParameter("end", end) :
                new ObjectParameter("end", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_8_Result>("sp_8", getmathuocParameter, gettenthuocParameter, startParameter, endParameter);
        }
    
        public virtual int sp_9(string mathuoc, string tenthuoc, string maloai, string mancc, string congdung, Nullable<System.DateTime> hsd, string dvt)
        {
            var mathuocParameter = mathuoc != null ?
                new ObjectParameter("mathuoc", mathuoc) :
                new ObjectParameter("mathuoc", typeof(string));
    
            var tenthuocParameter = tenthuoc != null ?
                new ObjectParameter("tenthuoc", tenthuoc) :
                new ObjectParameter("tenthuoc", typeof(string));
    
            var maloaiParameter = maloai != null ?
                new ObjectParameter("maloai", maloai) :
                new ObjectParameter("maloai", typeof(string));
    
            var manccParameter = mancc != null ?
                new ObjectParameter("mancc", mancc) :
                new ObjectParameter("mancc", typeof(string));
    
            var congdungParameter = congdung != null ?
                new ObjectParameter("congdung", congdung) :
                new ObjectParameter("congdung", typeof(string));
    
            var hsdParameter = hsd.HasValue ?
                new ObjectParameter("hsd", hsd) :
                new ObjectParameter("hsd", typeof(System.DateTime));
    
            var dvtParameter = dvt != null ?
                new ObjectParameter("dvt", dvt) :
                new ObjectParameter("dvt", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_9", mathuocParameter, tenthuocParameter, maloaiParameter, manccParameter, congdungParameter, hsdParameter, dvtParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    }
}
