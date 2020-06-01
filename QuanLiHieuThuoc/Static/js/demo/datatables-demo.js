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
$(() => {    var tablekh = $('#dataTableKhachHang').DataTable({        "ajax": "https://localhost:44369/khachhang/jsonkhachhang",        "columnDefs": [{            "targets": -1,            "data": null,            "defaultContent": '<button type="button" id = "btnEditKh" data-toggle="modal" data-target="#editModalKh" class="btn btn-primary"><i class="far fa-edit"></i> Sửa</button>&nbsp;<button type="button" class="btn btn-danger" id = "btnDeleteKh" data-toggle="modal" data-target="#deleteModalKh"><i class="far fa-trash-alt"></i> Xóa</button>'        }]    });    function reloadTableKh(tablekh) {        tablekh.ajax.reload();    }    function zipDataKh() {        let form = new FormData();        form.append('MaKH', $("#makhachhang").val());        form.append('TenKH', $("#tenkhachhang").val());        form.append('DiaChi', $("#diachi").val());        form.append('DienThoai', $("#dienthoai").val());        form.append('Email', $("#email").val());        return form;    }    function zipNewDataKh() {        let form = new FormData();        form.append('MaKH', $("#makhachhangmoi").val());        form.append('TenKH', $("#tenkhachhangmoi").val());        form.append('DiaChi', $("#diachimoi").val());        form.append('DienThoai', $("#dienthoaimoi").val());        form.append('Email', $("#emailmoi").val());        return form;    }    function bindDataKh(data) {        $("#makhachhang").val(data[0]);        $("#tenkhachhang").val(data[1]);        $("#diachi").val(data[2]);        $("#dienthoai").val(data[3]);        $("#email").val(data[4]);    }    function clearDataKh() {        $("#makhachhangmoi").val("");        $("#tenkhachhangmoi").val("");        $("#diachimoi").val("");        $("#dienthoaimoi").val("");        $("#emailmoi").val("");    }    $('#dataTableKhachHang tbody').on('click', '#btnEditKh', function () {        var data = tablekh.row($(this).parents('tr')).data();        bindDataKh(data);    });    $('#dataTableKhachHang tbody').on('click', '#btnDeleteKh', function () {        var data = tablekh.row($(this).parents('tr')).data();        bindDataKh(data);    });    $('#submitChangesKh').click(() => {        let formData = zipDataKh();        $.ajax({            url: 'https://localhost:44369/khachhang/editkhachhang',            data: formData,            processData: false,            contentType: false,            type: 'POST',            success: function (data) {                alert(data.message);                tablekh.ajax.reload();                $('#editModalKh').modal('hide');            }        });    });    $('#submitDeleteKh').click(() => {        let formData = zipDataKh();        $.ajax({            url: 'https://localhost:44369/khachhang/deletekhachhang',            data: formData,            processData: false,            contentType: false,            type: 'POST',            success: function (data) {                alert(data.message);                tablekh.ajax.reload();                $('#deleteModalKh').modal('hide');            }        });    });    $('#btnCreateKh').click(function () {        clearDataKh();    })    $('#submitCreateKh').click(() => {        let formData = zipNewDataKh();        $.ajax({            url: 'https://localhost:44369/khachhang/CreateKhachHang',            data: formData,            processData: false,            contentType: false,            type: 'POST',            success: function (data) {                if (data.code == 200) {                    alert(data.mes);                    tablekh.ajax.reload();                    $('#createModalKh').modal('hide');                    clearDataKh();                } else {                    alert("Thêm nhân viên thất bại: " + data.mes);                }            }        });    });});