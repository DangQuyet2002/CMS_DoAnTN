var table = null;
$(function () {
    tableTintuc();
    $("#btnSearch").on("click", function (e) {
        e.preventDefault();
        table.ajax.reload();
    })
})
tableTintuc = () => {
    debugger
    let config = {
        serverSide: true,
        //scrollY: "50vh",
        //scrollX: true,
        scrollCollapse: true,
        ordering: false,
        fixedHeader: true,
        ajax: {
            url: '/Products/_DSSanPham',
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
                data: "NamePro",
                name: "NamePro",
                title: "Tên sản phẩm "
            },
            {
                data: "Image",
                name: "Image",
                title: "Ảnh 1",
                render: function (data) {
                    return `<img src="/FileUploaded/${data}" width="50" height="60"/>`;
                }

            },
            {
                data: "Image1",
                name: "Image1",
                title: "Ảnh 2",
                render: function (data) {
                    return `<img src="/FileUploaded/${data}" width="50" height="60"/>`;
                }
            },
            {
                data: "TenCateMin",
                name: "TenCateMin",
                title: "Loại danh mục",

            },
            {
                data: "Quantity",
                name: "Quantity",
                title: "Số lượng",

            },
            {
                data: "TenCate",
                name: "TenCate",
                title: "Loại sản phẩm",

            },
            {
                data: "Id", title: "Sửa", name: "action",
                render: function (data) {
                    return `<div class="d-flex align-items-center gap-1">
                                        <button type="button" class="btn btn-sm btn-outline-warning btn-icon waves-effect waves-light" title="Sửa" onclick="btnThongTin(${data})">
                                            <svg viewBox="0 0 24 24" width="15" height="15" stroke="currentColor" stroke-width="2" fill="none" stroke-linecap="round" stroke-linejoin="round" class="css-i6dzq1"><path d="M12 20h9"></path><path d="M16.5 3.5a2.121 2.121 0 0 1 3 3L7 19l-4 1 1-4L16.5 3.5z"></path></svg>
                                        </button>
                                    </div>`;
                }
            },
            {
                data: "Id", title: "Thuộc tính", name: "action",
                render: function (data) {
                    return `<div class="d-flex align-items-center gap-1">
                                        <button type="button" class="btn btn-sm btn-outline-warning btn-icon waves-effect waves-light" title="Thêm thuộc tính" onclick="btnThuocTinh(${data})">
                                            <svg viewBox="0 0 24 24" width="15" height="15" stroke="currentColor" stroke-width="2" fill="none" stroke-linecap="round" stroke-linejoin="round" class="css-i6dzq1"><path d="M12 20h9"></path><path d="M16.5 3.5a2.121 2.121 0 0 1 3 3L7 19l-4 1 1-4L16.5 3.5z"></path></svg>
                                        </button>
                                    </div>`;
                }
            },
        ],
        columnDefs: [
            { width: 50, targets: [0] },
            { width: 450, targets: [1] },
            { width: 200, targets: [2] },
            { width: 200, targets: [3] },
            { width: 150, targets: [4, 5] },
            { width: 150, targets: [6] },
            { width: 50, targets: [7,8] }
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
    table = $.fn.initDataTable("#tableSanPham", config);


}

$("#btnThemMoi").on("click", function (e) {
    $.fn.getData('/Admin/Products/ThemMoi', {}, res => {
        $.fn.showModal({
            title: "THÊM MỚI",
            bodyContent: res,
            dialogClass: "mg"
        });
        LoadCategory();
        LoadDMCategory();
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
        $.fn.postData('/Admin/Products/Delete', { listId: listId.join(",") }, res => {
            $.fn.toastrMessage(res.massage, '', res.type);
            table.ajax.reload();
        });

    }
}

function LoadCategory() {
    $.fn.destroySelect2('#CategoryId');
    var data = {
        placeholder: '--Loại sản phẩm--'
    }
    $.fn.singleSelect('#CategoryId', '/Admin/LoaiSanPham/LoadCategory', data, res => {
        $('#CategoryId').val($("#valCategoryId").val()).trigger('change')
    });
}
function LoadDMCategory() {
    $.fn.destroySelect2('#Loai_Don_Vi_Id_Min');
    var data = {
        placeholder: '--Loại danh mục --'
    }
    $.fn.singleSelect('#Loai_Don_Vi_Id_Min', '/Admin/DMCategory/LoadDMCategory', data, res => {
        $('#Loai_Don_Vi_Id_Min').val($("#valLoai_Don_Vi_Min").val()).trigger('change')
    });
}
function btnThongTin(Id) {
    $.fn.getData('/Admin/Products/ChiTiet', { Id: Id }, res => {
        $.fn.showModal({
            title: "THÔNG TIN CHI TIẾT ",
            bodyContent: res,
            dialogClass: "lg"
        });
        LoadCategory();
        LoadDMCategory();
    })

}
function btnThuocTinh(Id) {
    $.fn.getData('/Admin/Products/ThuocTinh', { Id: Id }, res => {
        $.fn.showModal({
            title: "THÔNG TIN CHI TIẾT ",
            bodyContent: res,
            dialogClass: "lg"
        });
       
    })

}