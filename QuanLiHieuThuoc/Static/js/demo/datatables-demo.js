// Call the dataTables jQuery plugin
$(() => {
    $('#dataTableNhanVien').DataTable({
        "ajax": "https://localhost:44369/home/jsonnhanvien",
        "columns": [
            { "data": "MaNV" },
            { "data": "HoTen" },
            { "data": "ChucVu" },
            { "data": "GioiTinh" },
            { "data": "Ngaysinh" },
            { "data": "Diachi" },
            { "data": "Email" },
            { "data": "DienThoai" },
            { "data": "NgayLV" }
        ]
    });
});
