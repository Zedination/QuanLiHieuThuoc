﻿using System;
        // GET: KhachHang
        QLTHUOCEntities db = new QLTHUOCEntities();
        // GET: NhanVien
        public ActionResult DanhSachKhachHang()
                    String[] khs = { MaKH, TenKH, DiaChi, DienThoai, Email };
                    Email = kh.Email,
                db.Entry(temp).State = EntityState.Modified;