// Call the dataTables jQuery plugin
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
                alert(data.message);
                table.ajax.reload();
                $('#editModal').modal('hide');
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
                alert(data.message);
                table.ajax.reload();
                $('#deleteModal').modal('hide');
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
