﻿var table = null;
$(function () {
    tableDSAdmin();
    $("#btnSearch").on("click", function (e) {
        e.preventDefault();
        table.ajax.reload();
    })
})
tableDSAdmin = () => {
    var stt = 1;
    let config = {
        serverSide: true,
        //scrollY: "50vh",
        //scrollX: true,
        scrollCollapse: true,
        ordering: false,
        fixedHeader: true,
        ajax: {
            url: '/Admin/LoaiSanPham/DSLoaiSP',
            type: 'POST',
            data: (param) => {
                param.Keywords = $("#txtTukhoa").val();

            }
        },
        columns: [
            {
                data: "Id",
                name: "SelectBox",
                render: (data) => {
                    return `<div class="custom-control custom-checkbox ml-2">
                                <input type="checkbox" class="custom-control-input ckbChoDuyet" id="${data}" value="${data}">
                                <label class="custom-control-label" for="${data}"></label>
                            </div>`;
                }
            },
           
            {
                data: "Name",
                name: "Name",
                title: "Tên loại sản phẩm"
            },
            
            {
                data: "Id", title: "Hành động", name: "action",
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
            { width: 150, targets: [0] },
            { width: 1050, targets: [1] },
            { width: 150, targets: [2] }
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
    table = $.fn.initDataTable("#tableLoaiSP", config);


}
function btnThongTin(Id) {
    $.fn.getData('/Admin/LoaiSanPham/ChiTiet', { Id: Id }, res => {
        debugger;
        $.fn.showModal({
            title: "THÔNG TIN CHI TIẾT ",
            bodyContent: res,
            dialogClass: "lg"
        });

    })

}

$("#btnThemMoi").on("click", function (e) {
    $.fn.getData('/Admin/LoaiSanPham/ThemMoi', {}, res => {
        $.fn.showModal({
            title: "THÊM MỚI",
            bodyContent: res,
            dialogClass: "mg"
        });
    })
})
deleteTable = () => {
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
        $.fn.postData('/LoaiSanPham/Delete', { listId: listId.join(",") }, res => {
            $.fn.toastrMessage(res.massage, '', res.type);
            table.ajax.reload();
        });

    }
}