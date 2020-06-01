// Datatables script for "Nhân Viên"
$(() => {
    
    var table = $('#dataTableNhanVien').DataTable({
        "ajax": "https://localhost:44369/nhanvien/jsonnhanvien",
        "columnDefs": [{
            "targets": -1,
            "data": null,
            "defaultContent": '<button type="button" id = "btnEdit" data-toggle="modal" data-target="#editModal" class="btn btn-primary"><i class="far fa-edit"></i> Sửa</button>&nbsp;<button type="button" class="btn btn-danger" id = "btnDelete" data-toggle="modal" data-target="#deleteModal"><i class="far fa-trash-alt"></i> Xóa</button>'
        }]
    });
    function reloadTable(table) {
        table.ajax.reload();
    }
    function zipData() {
        let form = new FormData();
        form.append('MaNV', $("#manhanvien").val());
        form.append('HoTen', $("#tennhanvien").val());
        form.append('ChucVu', $("#chucvu").val());
        form.append('GioiTinh', $("#gioitinh").val());
        form.append('Ngaysinh', $("#ngaysinh").val());
        form.append('Diachi', $("#diachi").val());
        form.append('Email', $("#email").val());
        form.append('DienThoai', $("#dienthoai").val());
        form.append('NgayLV', $("#ngaylamviec").val());
        return form;
    }
    function zipNewData() {
        let form = new FormData();
        form.append('MaNV', $("#manhanvienmoi").val());
        form.append('HoTen', $("#tennhanvienmoi").val());
        form.append('ChucVu', $("#chucvumoi").val());
        form.append('GioiTinh', $("#gioitinhmoi").val());
        form.append('Ngaysinh', $("#ngaysinhmoi").val());
        form.append('Diachi', $("#diachimoi").val());
        form.append('Email', $("#emailmoi").val());
        form.append('DienThoai', $("#dienthoaimoi").val());
        form.append('NgayLV', $("#ngaylamviecmoi").val());
        return form;
    }
    function bindData(data) {
        $("#manhanvien").val(data[0]);
        $("#tennhanvien").val(data[1]);
        $("#chucvu").val(data[2]);
        $("#gioitinh").val(data[3]);
        $("#ngaysinh").val(data[4]);
        $("#diachi").val(data[5]);
        $("#email").val(data[6]);
        $("#dienthoai").val(data[7]);
        $("#ngaylamviec").val(data[8]);
    }
    function clearData() {
        $("#manhanvienmoi").val("");
        $("#tennhanvienmoi").val("");
        $("#chucvumoi").val("");
        $("#gioitinhmoi").val("");
        $("#ngaysinhmoi").val("");
        $("#diachimoi").val("");
        $("#emailmoi").val("");
        $("#dienthoaimoi").val("");
        $("#ngaylamviecmoi").val("");
    }
    $('#dataTableNhanVien tbody').on('click', '#btnEdit', function () {
        var data = table.row($(this).parents('tr')).data();
        bindData(data);
    });
    $('#dataTableNhanVien tbody').on('click', '#btnDelete', function () {
        var data = table.row($(this).parents('tr')).data();
        bindData(data);
    });
    $('#submitChanges').click(() => {
        let formData = zipData();
        $.ajax({
            url: 'https://localhost:44369/nhanvien/editnhanvien',
            data: formData,
            processData: false,
            contentType: false,
            type: 'POST',
            success: function (data) {
                if (data.success == true) {
                    alert(data.message);
                    table.ajax.reload();
                    $('#editModal').modal('hide');
                } else {
                    alert(data.message);
                }
            }
        });
    });
    $('#submitDelete').click(() => {
        let formData = zipData();
        $.ajax({
            url: 'https://localhost:44369/nhanvien/deletenhanvien',
            data: formData,
            processData: false,
            contentType: false,
            type: 'POST',
            success: function (data) {
                if (data.success == true) {
                    alert(data.message);
                    table.ajax.reload();
                    $('#deleteModal').modal('hide');
                } else {
                    alert(data.message);
                    $('#deleteModal').modal('hide');
                }
            }
        });
    });
    $('#btnCreate').click(function () {
        clearData();
    })
    $('#submitCreate').click(() => {
        let formData = zipNewData();
        $.ajax({
            url: 'https://localhost:44369/nhanvien/createnhanvien',
            data: formData,
            processData: false,
            contentType: false,
            type: 'POST',
            success: function (data) {
                if (data.code == 200) {
                    alert(data.mes);
                    table.ajax.reload();
                    $('#createModal').modal('hide');
                    clearData();
                } else {
                    alert("Thêm nhân viên thất bại: " + data.mes);
                }
            }
        });
    });
});
//DataTables crript for Thuốc
$(() => {
    var tableThuoc = $('#dataTableThuoc').DataTable({
        "ajax": "https://localhost:44369/thuoc/jsonthuoc",
        "columnDefs": [{
            "targets": -1,
            "data": null,
            "defaultContent": '<button type="button" id = "btnEditThuoc" data-toggle="modal" data-target="#editModalThuoc" class="btn btn-primary"><i class="far fa-edit"></i> Sửa</button>&nbsp;<button type="button" class="btn btn-danger" id = "btnDeleteThuoc" data-toggle="modal" data-target="#deleteModalThuoc"><i class="far fa-trash-alt"></i> Xóa</button>'
        }]
    });
    function reloadTableThuoc(table) {
        table.ajax.reload();
    }
    function zipDataThuoc() {
        let form = new FormData();
        form.append('MaThuoc', $("#mathuoc").val());
        form.append('TenThuoc', $("#tenthuoc").val());
        form.append('MaLoaiThuoc', $("#maloaithuoc").val());
        form.append('MaNCC', $("#mancc").val());
        form.append('CongDung', $("#congdung").val());
        form.append('HanSuDung', $("#hansudung").val());
        form.append('Donviting', $("#donvitinh").val());
        form.append('SoLuong', $("#soluong").val());
        form.append('DonGiaNhap', $("#dongianhap").val());
        return form;
    }
    function zipNewDataThuoc() {
        let form = new FormData();
        form.append('MaThuoc', $("#mathuocmoi").val());
        form.append('TenThuoc', $("#tenthuocmoi").val());
        form.append('MaLoaiThuoc', $("#maloaithuocmoi").val());
        form.append('MaNCC', $("#manccmoi").val());
        form.append('CongDung', $("#congdungmoi").val());
        form.append('HanSuDung', $("#hansudungmoi").val());
        form.append('Donviting', $("#donvitinhmoi").val());
        form.append('SoLuong', parseInt($("#soluongmoi").val()));
        form.append('DonGiaNhap', $("#dongianhapmoi").val());
        return form;
    }
    function bindDataThuoc(data) {
        $("#mathuoc").val(data[0]);
        $("#tenthuoc").val(data[1]);
        $("#maloaithuoc").val(data[2]);
        $("#mancc").val(data[3]);
        $("#congdung").val(data[4]);
        $("#hansudung").val(data[5]);
        $("#donvitinh").val(data[6]);
        $("#soluong").val(data[7]);
        $("#dongianhap").val(data[8]);
    }
    function clearDataThuoc() {
        $("#mathuoc").val('');
        $("#tenthuoc").val('');
        $("#maloaithuoc").val('');
        $("#mancc").val('');
        $("#congdung").val('');
        $("#hansudung").val('');
        $("#donvitinh").val('');
        $("#soluong").val('');
        $("#dongianhap").val('');
    }
    $('#dataTableThuoc tbody').on('click', '#btnEditThuoc', function () {
        var data = tableThuoc.row($(this).parents('tr')).data();
        bindDataThuoc(data);
    });
    $('#dataTableThuoc tbody').on('click', '#btnDeleteThuoc', function () {
        var data = tableThuoc.row($(this).parents('tr')).data();
        bindDataThuoc(data);
    });
    $('#submitChangesThuoc').click(() => {
        let formData = zipDataThuoc();
        $.ajax({
            url: 'https://localhost:44369/thuoc/editthuoc',
            data: formData,
            processData: false,
            contentType: false,
            type: 'POST',
            success: function (data) {
                if (data.success == true) {
                    alert(data.message);
                    tableThuoc.ajax.reload();
                    $('#editModalThuoc').modal('hide');
                } else {
                    alert(data.message);
                }
            }
        });
    });
    $('#submitDeleteThuoc').click(() => {
        let formData = zipDataThuoc();
        $.ajax({
            url: 'https://localhost:44369/thuoc/deletethuoc',
            data: formData,
            processData: false,
            contentType: false,
            type: 'POST',
            success: function (data) {
                if (data.success == true) {
                    alert(data.message);
                    tableThuoc.ajax.reload();
                    $('#deleteModalThuoc').modal('hide');
                } else {
                    alert(data.message);
                    $('#deleteModalThuoc').modal('hide');
                }
            }
        });
    });
    $('#btnCreateThuoc').click(function () {
        clearDataThuoc();
    })
    $('#submitCreateThuoc').click(() => {
        let formData = zipNewDataThuoc();
        $.ajax({
            url: 'https://localhost:44369/thuoc/createthuoc',
            data: formData,
            processData: false,
            contentType: false,
            type: 'POST',
            success: function (data) {
                if (data.code == 200) {
                    alert(data.mes);
                    tableThuoc.ajax.reload();
                    $('#createModalThuoc').modal('hide');
                    clearData();
                } else {
                    alert("Thêm thuốc thất bại: " + data.mes);
                }
            }
        });
    });
});
//Datatables for "Khách Hàng"
$(() => {

    var tablekh = $('#dataTableKhachHang').DataTable({
        "ajax": "https://localhost:44369/khachhang/jsonkhachhang",
        "columnDefs": [{
            "targets": -1,
            "data": null,
            "defaultContent": '<button type="button" id = "btnEditKh" data-toggle="modal" data-target="#editModalKh" class="btn btn-primary"><i class="far fa-edit"></i> Sửa</button>&nbsp;<button type="button" class="btn btn-danger" id = "btnDeleteKh" data-toggle="modal" data-target="#deleteModalKh"><i class="far fa-trash-alt"></i> Xóa</button>'
        }]
    });
    function reloadTableKh(tablekh) {
        tablekh.ajax.reload();
    }
    function zipDataKh() {
        let form = new FormData();
        form.append('MaKH', $("#makhachhang").val());
        form.append('TenKH', $("#tenkhachhang").val());
        form.append('DiaChi', $("#diachi").val());
        form.append('DienThoai', $("#dienthoai").val());
        form.append('Email', $("#email").val());
        return form;
    }
    function zipNewDataKh() {
        let form = new FormData();
        form.append('MaKH', $("#makhachhangmoi").val());
        form.append('TenKH', $("#tenkhachhangmoi").val());
        form.append('DiaChi', $("#diachimoi").val());
        form.append('DienThoai', $("#dienthoaimoi").val());
        form.append('Email', $("#emailmoi").val());
        return form;
    }
    function bindDataKh(data) {
        $("#makhachhang").val(data[0]);
        $("#tenkhachhang").val(data[1]);
        $("#diachi").val(data[2]);
        $("#dienthoai").val(data[3]);
        $("#email").val(data[4]);
    }
    function clearDataKh() {
        $("#makhachhangmoi").val("");
        $("#tenkhachhangmoi").val("");
        $("#diachimoi").val("");
        $("#dienthoaimoi").val("");
        $("#emailmoi").val("");
    }
    $('#dataTableKhachHang tbody').on('click', '#btnEditKh', function () {
        var data = tablekh.row($(this).parents('tr')).data();
        bindDataKh(data);
    });
    $('#dataTableKhachHang tbody').on('click', '#btnDeleteKh', function () {
        var data = tablekh.row($(this).parents('tr')).data();
        bindDataKh(data);
    });
    $('#submitChangesKh').click(() => {
        let formData = zipDataKh();
        $.ajax({
            url: 'https://localhost:44369/khachhang/editkhachhang',
            data: formData,
            processData: false,
            contentType: false,
            type: 'POST',
            success: function (data) {
                alert(data.message);
                tablekh.ajax.reload();
                $('#editModalKh').modal('hide');
            }
        });
    });
    $('#submitDeleteKh').click(() => {
        let formData = zipDataKh();
        $.ajax({
            url: 'https://localhost:44369/khachhang/deletekhachhang',
            data: formData,
            processData: false,
            contentType: false,
            type: 'POST',
            success: function (data) {
                alert(data.message);
                tablekh.ajax.reload();
                $('#deleteModalKh').modal('hide');
            }
        });
    });
    $('#btnCreateKh').click(function () {
        clearDataKh();
    })
    $('#submitCreateKh').click(() => {
        let formData = zipNewDataKh();
        $.ajax({
            url: 'https://localhost:44369/khachhang/CreateKhachHang',
            data: formData,
            processData: false,
            contentType: false,
            type: 'POST',
            success: function (data) {
                if (data.code == 200) {
                    alert(data.mes);
                    tablekh.ajax.reload();
                    $('#createModalKh').modal('hide');
                    clearDataKh();
                } else {
                    alert("Thêm nhân viên thất bại: " + data.mes);
                }
            }
        });
    });
});
//Datatables script cho "Hóa đơn nhập" và "Chi tiết hóa đơn nhập"
$(() => {

    var tablehdn = $('#dataTableHoaDonNhap').DataTable({
        "ajax": "https://localhost:44369/hoadonnhap/jsonhoadonnhap",
        "columnDefs": [{
            "targets": -1,
            "data": null,
            "defaultContent": '<button type="button" id = "btnEditHDN" data-toggle="modal" data-target="#editModalHDN" class="btn btn-primary"><i class="far fa-edit"></i> Sửa</button>&nbsp;<button type="button" class="btn btn-danger" id = "btnDeleteHDN" data-toggle="modal" data-target="#deleteModalHDN"><i class="far fa-trash-alt"></i> Xóa</button>&nbsp<button type="button" id = "btnDetailHDN" data-toggle="modal" data-target="#DetailModalCTHDN" class="btn btn-primary"><i class="fas fa-info-circle"></i> Xem chi tiết</button>'
        }]
    });
    function reloadTableHDN(tablehdn) {
        tablehdn.ajax.reload();
    }
    function zipDataHDN() {
        let form = new FormData();
        form.append('MaHDN', $("#mahdn").val());
        form.append('MaNV', $("#manhanvien").val());
        form.append('NgayNhap', $("#ngaynhap").val());
        form.append('MaNCC', $("#mancc").val());
        return form;
    }
    function zipNewDataHDN() {
        let form = new FormData();
        form.append('MaHDN', $("#mahdnmoi").val());
        form.append('MaNV', $("#manhanvienmoi").val());
        form.append('NgayNhap', $("#ngaynhapmoi").val());
        form.append('MaNCC', $("#manccmoi").val());
        return form;
    }
    function bindDataHDN(data) {
        $("#mahdn").val(data[0]);
        $("#manhanvien").val(data[1]);
        $("#ngaynhap").val(data[2]);
        $('#mancc').val(data[3]);
    }
    function clearDataHDN() {
        $("#mahdnmoi").val("");
        $("#manhanvienmoi").val("");
        $("#ngaynhapmoi").val("");
        $("#manccmoi").val("");
    }
    function clearDataCTHDN() {
        $("#dongianhap-ct").val("");
        $("#soluongnhap-ct").val("");
    }
    $('#dataTableHoaDonNhap tbody').on('click', '#btnEditHDN', function () {
        var data = tablehdn.row($(this).parents('tr')).data();
        bindDataHDN(data);
    });
    $('#dataTableHoaDonNhap tbody').on('click', '#btnDeleteHDN', function () {
        var data = tablehdn.row($(this).parents('tr')).data();
        bindDataHDN(data);
    });
    $('#submitChangesHDN').click(() => {
        let formData = zipDataHDN();
        $.ajax({
            url: 'https://localhost:44369/hoadonnhap/edithoadonnhap',
            data: formData,
            processData: false,
            contentType: false,
            type: 'POST',
            success: function (data) {
                alert(data.message);
                tablehdn.ajax.reload();
                $('#editModalHDN').modal('hide');
            }
        });
    });
    $('#submitDeleteHDN').click(() => {
        let formData = zipDataHDN();
        $.ajax({
            url: 'https://localhost:44369/hoadonnhap/deletehoadonnhap',
            data: formData,
            processData: false,
            contentType: false,
            type: 'POST',
            success: function (data) {
                alert(data.message);
                tablehdn.ajax.reload();
                $('#deleteModalHDN').modal('hide');
            }
        });
    });
    $('#btnCreateHDN').click(function () {
        clearDataHDN();
    })
    $('#submitCreateHDN').click(() => {
        let formData = zipNewDataHDN();
        $.ajax({
            url: 'https://localhost:44369/hoadonnhap/CreateHoaDonNhap',
            data: formData,
            processData: false,
            contentType: false,
            type: 'POST',
            success: function (data) {
                if (data.code == 200) {
                    alert(data.mes);
                    tablehdn.ajax.reload();
                    $('#createModalHDN').modal('hide');
                    clearDataHDN();
                } else {
                    alert("Thêm hóa đơn nhập thất bại: " + data.mes);
                }
            }
        });
    });
    //Chi tiết hóa đơn xuất
    var tablecthdn = $('#dataTableCTHoaDonNhap').DataTable({
        "ajax": "https://localhost:44369/hoadonnhap/jsoncthdn",
        "columnDefs": [{
            "targets": -1,
            "data": null,
            "defaultContent": '<button type="button" id = "btnDetailCTHDN" class="btn btn-primary"><i class="fas fa-info-circle"></i></button>'
        }]
    });
    $('#dataTableHoaDonNhap tbody').on('click', '#btnDetailHDN', function () {
        var data = tablehdn.row($(this).parents('tr')).data();
        $("#mahdn-ct").val(data[0]);
        tablecthdn.search(data[0]).draw();
    });
    $('#dataTableCTHoaDonNhap tbody').on('click', '#btnDetailCTHDN', function () {
        var data = tablecthdn.row($(this).parents('tr')).data();
        $('#mathuoc-ct').val(data[1]);
        $("#dongianhap-ct").val(data[2]);
        $("#soluongnhap-ct").val(data[3]);
    });
    $('#SubmitCreateCTHDN').click(() => {
        let formData = new FormData();
        formData.append("MaHDN", $("#mahdn-ct").val());
        formData.append("MaThuoc", $("#mathuoc-ct").val());
        formData.append("DonGiaNhap", $("#dongianhap-ct").val());
        formData.append("SoluongNhap", $("#soluongnhap-ct").val());
        $.ajax({
            url: 'https://localhost:44369/hoadonnhap/CreateCTHDN',
            data: formData,
            processData: false,
            contentType: false,
            type: 'POST',
            success: function (data) {
                if (data.code == 200) {
                    alert(data.mes);
                    tablecthdn.ajax.reload();
                    clearDataCTHDN();
                } else {
                    alert("Thêm hóa đơn nhập thất bại: " + data.mes);
                }
            }
        });
    });
    $("#SubmitResetCRUD").click(() => {
        clearDataCTHDN();
    });
    $("#SubmitEditCTHDN").click(() => {
        let formData = new FormData();
        formData.append("MaHDN", $("#mahdn-ct").val());
        formData.append("MaThuoc", $("#mathuoc-ct").val());
        formData.append("DonGiaNhap", $("#dongianhap-ct").val());
        formData.append("SoluongNhap", $("#soluongnhap-ct").val());
        $.ajax({
            url: 'https://localhost:44369/hoadonnhap/editcthdn',
            data: formData,
            processData: false,
            contentType: false,
            type: 'POST',
            success: function (data) {
                alert(data.message);
                tablecthdn.ajax.reload();
            }
        });
    });
    $("#SubmitDeleteCTHDN").click(() => {
        let formData = new FormData();
        formData.append("MaHDN", $("#mahdn-ct").val());
        formData.append("MaThuoc", $("#mathuoc-ct").val());
        formData.append("DonGiaNhap", $("#dongianhap-ct").val());
        formData.append("SoluongNhap", $("#soluongnhap-ct").val());
        $.ajax({
            url: 'https://localhost:44369/hoadonnhap/deletecthdn',
            data: formData,
            processData: false,
            contentType: false,
            type: 'POST',
            success: function (data) {
                alert(data.mes);
                tablecthdn.ajax.reload();
            }
        });
    });
});
//Scripts datatables cho Nhà Cung Cấp

$(() => {

    var tablencc = $('#dataTableNCC').DataTable({
        "ajax": "https://localhost:44369/ncc/jsonNCC",
        "columnDefs": [{
            "targets": -1,
            "data": null,
            "defaultContent": '<button type="button" id = "btnEditNCC" data-toggle="modal" data-target="#editModalNCC" class="btn btn-primary"><i class="far fa-edit"></i> Sửa</button>&nbsp;<button type="button" class="btn btn-danger" id = "btnDeleteNCC" data-toggle="modal" data-target="#deleteModalNCC"><i class="far fa-trash-alt"></i> Xóa</button>'
        }]
    });
    function reloadTable(tablencc) {
        tablencc.ajax.reload();
    }
    function zipDataNCC() {
        let form = new FormData();
        form.append('MaNCC', $("#mancc").val());
        form.append('TenNCC', $("#tenncc").val());
        form.append('Diachi', $("#diachi").val());
        form.append('DienThoai', $("#dienthoai").val());
        form.append('Email', $("#email").val());
        return form;
    }
    function zipNewDataNCC() {
        let form = new FormData();
        form.append('MaNCC', $("#manccmoi").val());
        form.append('TenNCC', $("#tennccmoi").val());
        form.append('Diachi', $("#diachimoi").val());
        form.append('DienThoai', $("#dienthoaimoi").val());
        form.append('Email', $("#emailmoi").val());
        return form;
    }
    function bindDataNCC(data) {
        $("#mancc").val(data[0]);
        $("#tenncc").val(data[1]);
        $("#diachi").val(data[2]);
        $("#dienthoai").val(data[3]);
        $("#email").val(data[4]);
    }
    function clearDataNCC() {
        $("#manccmoi").val("");
        $("#tennccmoi").val("");
        $("#diachimoi").val("");
        $("#dienthoaimoi").val("");
        $("#emailmoi").val("");
    }
    $('#dataTableNCC tbody').on('click', '#btnEditNCC', function () {
        var data = tablencc.row($(this).parents('tr')).data();
        bindDataNCC(data);
    });
    $('#dataTableNCC tbody').on('click', '#btnDeleteNCC', function () {
        var data = tablencc.row($(this).parents('tr')).data();
        bindDataNCC(data);
    });
    $('#submitChangesNCC').click(() => {
        let formData = zipDataNCC();
        $.ajax({
            url: 'https://localhost:44369/ncc/editncc',
            data: formData,
            processData: false,
            contentType: false,
            type: 'POST',
            success: function (data) {
                alert(data.message);
                tablencc.ajax.reload();
                $('#editModalNCC').modal('hide');
            }
        });
    });
    $('#submitDeleteNCC').click(() => {
        let formData = zipDataNCC();
        $.ajax({
            url: 'https://localhost:44369/ncc/deletencc',
            data: formData,
            processData: false,
            contentType: false,
            type: 'POST',
            success: function (data) {
                alert(data.message);
                tablencc.ajax.reload();
                $('#deleteModalNCC').modal('hide');
            }
        });
    });
    $('#btnCreateNcc').click(function () {
        clearDataNCC();
    })
    $('#submitCreateNCC').click(() => {
        let formData = zipNewDataNCC();
        $.ajax({
            url: 'https://localhost:44369/ncc/createncc',
            data: formData,
            processData: false,
            contentType: false,
            type: 'POST',
            success: function (data) {
                if (data.code == 200) {
                    alert(data.mes);
                    tablencc.ajax.reload();
                    $('#createModalNCC').modal('hide');
                    clearDataNCC();
                } else {
                    alert("Thêm NCC thất bại: " + data.mes);
                }
            }
        });
    });
});
//Chi tiết hóa đơn xuất
$(() => {

    var tableHDX = $('#dataTableHDX').DataTable({
        "ajax": "https://localhost:44369/HoaDonXuat/JsonHoaDonXuat",
        "columnDefs": [{
            "targets": -1,
            "data": null,
            "defaultContent": '<button type="button" id = "btnEditHDX" data-toggle="modal" data-target="#editModalHDX" class="btn btn-primary"><i class="far fa-edit"></i> Sửa</button>&nbsp;<button type="button" class="btn btn-danger" id = "btnDeleteHDX" data-toggle="modal" data-target="#deleteModalHDX"><i class="far fa-trash-alt"></i> Xóa</button>&nbsp;<button type="button" class="btn btn-primary" id = "btnDetailHDX" data-toggle="modal" data-target="#DetailModalCTHDX"><i class="fas fa-info-circle"></i> Chi tiết</button>'
        }]
    });
    function reloadTable(table) {
        tableHDX.ajax.reload();
    }
    function zipDataHDX() {
        let form = new FormData();
        form.append('MaHDX', $("#mahoadonxuat").val());
        form.append('MaNV', $("#manhanvien").val());
        form.append('MaKH', $("#makhachhang").val());
        form.append('NgayXuat', $("#ngayxuat").val());
        form.append('BacSi', $("#bacsi").val());
        form.append('DVCT', $("#dvct").val());
        return form;
    }
    function zipNewDataHDX() {
        let form = new FormData();
        form.append('MaHDX', $("#mahoadonxuatmoi").val());
        form.append('MaNV', $("#manhanvienmoi").val());
        form.append('MaKH', $("#makhachhangmoi").val());
        form.append('NgayXuat', $("#ngayxuatmoi").val());
        form.append('BacSi', $("#bacsimoi").val());
        form.append('DVCT', $("#dvctmoi").val());
        return form;
    }
    function bindDataHDX(data) {
        $("#mahoadonxuat").val(data[0]);
        $("#manhanvien").val(data[1]);
        $("#makhachhang").val(data[2]);
        $("#ngayxuat").val(data[3]);
        $("#bacsi").val(data[4]);
        $("#dvct").val(data[5]);
    }
    function clearDataHDX() {
        $("#mahoadonxuatmoi").val("");
        $("#manhanvienmoi").val("");
        $("#makhachhangmoi").val("");
        $("#ngayxuatmoi").val("");
        $("#bacsimoi").val("");
        $("#dvctmoi").val("");
    }
    $('#dataTableHDX tbody').on('click', '#btnEditHDX', function () {
        var data = tableHDX.row($(this).parents('tr')).data();
        bindDataHDX(data);
    });
    $('#dataTableHDX tbody').on('click', '#btnDeleteHDX', function () {
        var data = tableHDX.row($(this).parents('tr')).data();
        bindDataHDX(data);
    });
    $('#submitChangesHDX').click(() => {
        let formData = zipDataHDX();
        $.ajax({
            url: 'https://localhost:44369/hoadonxuat/EditHoaDonXuat',
            data: formData,
            processData: false,
            contentType: false,
            type: 'POST',
            success: function (data) {
                alert(data.message);
                tableHDX.ajax.reload();
                $('#editModalHDX').modal('hide');
            }
        });
    });
    $('#submitDeleteHDX').click(() => {
        let formData = zipDataHDX();
        $.ajax({
            url: 'https://localhost:44369/hoadonxuat/DeleteHoaDonXuat',
            data: formData,
            processData: false,
            contentType: false,
            type: 'POST',
            success: function (data) {
                alert(data.message);
                tableHDX.ajax.reload();
                $('#deleteModalHDX').modal('hide');
            }
        });
    });
    $('#btnCreateHDX').click(function () {
        clearDataHDX();
    })
    $('#submitCreateHDX').click(() => {
        let formData = zipNewDataHDX();
        $.ajax({
            url: 'https://localhost:44369/hoadonxuat/CreateHoaDonXuat',
            data: formData,
            processData: false,
            contentType: false,
            type: 'POST',
            success: function (data) {
                if (data.code == 200) {
                    alert(data.mes);
                    tableHDX.ajax.reload();
                    $('#createModalHDX').modal('hide');
                    clearDataHDX();
                } else {
                    alert("Thêm nhân viên thất bại: " + data.mes);
                }
            }
        });
    });
    //chi tiết hdx
    function clearDataCTHDX() {
        $("#dongiaban-ct").val("");
        $("#soluongban-ct").val("");
    }
    var tablecthdx = $('#dataTableCTHoaDonXuat').DataTable({
        "ajax": "https://localhost:44369/hoadonxuat/jsoncthdx",
        "columnDefs": [{
            "targets": -1,
            "data": null,
            "defaultContent": '<button type="button" id = "btnDetailCTHDX" class="btn btn-primary"><i class="fas fa-info-circle"></i></button>'
        }]
    });
    $('#dataTableHDX tbody').on('click', '#btnDetailHDX', function () {
        var data = tableHDX.row($(this).parents('tr')).data();
        $("#mahdx-ct").val(data[0]);
        tablecthdx.search(data[0]).draw();
    });
    $('#dataTableCTHoaDonXuat tbody').on('click', '#btnDetailCTHDX', function () {
        var data = tablecthdx.row($(this).parents('tr')).data();
        $('#mathuoc-ctx').val(data[1]);
        $("#dongiaban-ct").val(data[2]);
        $("#soluongban-ct").val(data[3]);
    });
    $('#SubmitCreateCTHDX').click(() => {
        let formData = new FormData();
        formData.append("MaHDX", $("#mahdx-ct").val());
        formData.append("MaThuoc", $("#mathuoc-ctx").val());
        formData.append("DonGiaBan", $("#dongiaban-ct").val());
        formData.append("SoluongBan", $("#soluongban-ct").val());
        $.ajax({
            url: 'https://localhost:44369/hoadonxuat/CreateCTHDX',
            data: formData,
            processData: false,
            contentType: false,
            type: 'POST',
            success: function (data) {
                if (data.code == 200) {
                    alert(data.mes);
                    tablecthdx.ajax.reload();
                    clearDataCTHDX();
                } else {
                    alert("Thêm hóa đơn nhập thất bại: " + data.mes);
                }
            }
        });
    });
    $("#SubmitResetCRUDHDX").click(() => {
        clearDataCTHDX();
    });
    $("#SubmitEditCTHDX").click(() => {
        let formData = new FormData();
        formData.append("MaHDX", $("#mahdx-ct").val());
        formData.append("MaThuoc", $("#mathuoc-ctx").val());
        formData.append("DonGiaBan", $("#dongiaban-ct").val());
        formData.append("SoluongBan", $("#soluongban-ct").val());
        $.ajax({
            url: 'https://localhost:44369/hoadonxuat/editcthdx',
            data: formData,
            processData: false,
            contentType: false,
            type: 'POST',
            success: function (data) {
                alert(data.message);
                tablecthdx.ajax.reload();
            }
        });
    });
    $("#SubmitDeleteCTHDX").click(() => {
        let formData = new FormData();
        formData.append("MaHDX", $("#mahdx-ct").val());
        formData.append("MaThuoc", $("#mathuoc-ctx").val());
        formData.append("DonGiaBan", $("#dongiaban-ct").val());
        formData.append("SoluongBan", $("#soluongban-ct").val());
        $.ajax({
            url: 'https://localhost:44369/hoadonxuat/deletecthdx',
            data: formData,
            processData: false,
            contentType: false,
            type: 'POST',
            success: function (data) {
                alert(data.mes);
                tablecthdx.ajax.reload();
            }
        });
    });
});

