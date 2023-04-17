﻿var table = null;
$(function () {
    tableDSUser();
    $("#btnSearch").on("click", function (e) {
        e.preventDefault();
        table.ajax.reload();
    })
})

tableDSUser = () => {
    debugger

    let config = {
        serverSide: true,
        //scrollY: "50vh",
        //scrollX: true,
        scrollCollapse: true,
        ordering: false,
        fixedHeader: true,

        ajax: {
            url: '/Admin/Login/DanhSachAdmin',
            type: 'POST',
            data: (param) => {
                param.Keywords = $("#txtTukhoa").val();

            },
        },
        columns: [
            {
                data: "ID",
                name: "SelectBox",
                render: (data) => {
                    return `<div class="custom-control custom-checkbox ml-2">
                                <input type="checkbox" class="custom-control-input ckbChoDuyet" id="${data}" value="${data}">
                                <label class="custom-control-label" for="${data}"></label>
                            </div>`;
                }
            },
            {
                data: "UserName",
                name: "UserName",
                title: "Tài khoản"
            },
            {
                data: "Password",
                name: "Password",
                title: "Mật khẩu",
                
                render: function (data) {
                    return $("<div>").text(data).html();
                }
            },
            {
                data: "FullName",
                name: "FullName",
                title: "Họ tên",

            },
            {
                data: "Email",
                name: "Email",
                title: "Email",

            },
            {
                data: "Phone",
                name: "Phone",
                title: "Điện thoại",

            },
            {
                data: "ID", title: "Hành động", name: "action",
                render: function (data) {
                    return `<div class="d-flex align-items-center gap-1">
                                        <button type="button" class="btn btn-sm btn-outline-warning btn-icon waves-effect waves-light" title="Sửa" onclick="btnThongTin(${data})">
                                            <svg viewBox="0 0 24 24" width="15" height="15" stroke="currentColor" stroke-width="2" fill="none" stroke-linecap="round" stroke-linejoin="round" class="css-i6dzq1"><path d="M12 20h9"></path><path d="M16.5 3.5a2.121 2.121 0 0 1 3 3L7 19l-4 1 1-4L16.5 3.5z"></path></svg>
                                        </button>
                                    </div>`;
                }
            },
        ],
        columnDefs: [
            { width: 50, targets: [0] },
            { width: 150, targets: [1] },
            { width: 350, targets: [2] },
            { width: 150, targets: [3, 4] }
        ],
        drawCallback: () => {
            /* dsNhomCanBoInit();*/
        },
        headerCallback: function (thead, data, start, end, display) {
            $(thead).find('th').eq(0).html('<input type="checkbox" class="form-check-input" id="chkNhomCanBoAll" />');
            $('#chkNhomCanBoAll').change(function () {
                $('.ckbChoDuyet').each(function () {
                    $(this).prop('checked', $('#chkNhomCanBoAll').prop('checked'));
                    $(this).change();
                })
            })
        },
    }
    table = $.fn.initDataTable("#tableUser", config);


}
function btnThongTin(Id) {
    $.fn.getData('/Admin/AccountAdmin/ChiTiet', { Id: Id }, res => {
        debugger;
        $.fn.showModal({
            title: "THÔNG TIN CHI TIẾT ",
            bodyContent: res,
            dialogClass: "lg"
        });

    })

}
$("#btnThemMoi").on("click", function (e) {
    $.fn.getData('/Admin/AccountAdmin/ThemMoi', {}, res => {
        $.fn.showModal({
            title: "THÊM MỚI",
            bodyContent: res,
            dialogClass: "lg"
        });
    })
})
function deleteTable() {
    var listId = [];
    $('.ckbChoDuyet').each(function () {
        var _checked = $(this).is(":checked")
        if (_checked) {
            listId.push($(this).prop("value"));
        }
    })
    if (listId.length == 0) {
        $.fn.toastrMessage('Vui lòng chọn ít nhất một dữ liệu!!!', '', 'warning');
        return;
    }
    if (confirm("Bạn chắc chắn muốn xóa những dữ liệu này?")) {
        $.fn.postData('/AccountAdmin/Delete', { listId: listId.join(",") }, res => {
            $.fn.toastrMessage(res.massage, '', res.type);
            table.ajax.reload();
        });

    }
}