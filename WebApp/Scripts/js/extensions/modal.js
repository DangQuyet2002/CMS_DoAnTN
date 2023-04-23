$.fn.showModal = (config) => {
    let defaultConfig = {
        title: "",
        bodyContent: "",
        dialogClass: "",
        buttonSave: !0
    }
    defaultConfig = $.extend({}, defaultConfig, config);
    $("#modal .nv-modal-body").html(defaultConfig.bodyContent);
    $("#modal .nv-modal-title").html(defaultConfig.title);
    $("#modal").attr("class", "nv-modal").addClass(defaultConfig.dialogClass);
    defaultConfig.buttonSave ? $("#modal #btnSave").show() : $("#modal #btnSave").hide();
    $("#modal").fadeIn('', () => {
        $($.fn.dataTable.tables(true)).DataTable()
            .columns.adjust();
    });
}

$.fn.showSubModal = (config) => {
    let defaultConfig = {
        title: "",
        bodyContent: "",
        dialogClass: "",
        buttonSave: !0
    }
    defaultConfig = $.extend({}, defaultConfig, config);
    $("#sub-modal .modal-body").html(defaultConfig.bodyContent);
    $("#sub-modal .modal-title").html(defaultConfig.title);
    $("#sub-modal .modal-dialog").attr("class", "modal-dialog").addClass(defaultConfig.dialogClass);
    defaultConfig.buttonSave ? $("#sub-modal #btnSubSave").show() : $("#sub-modal #btnSubSave").hide();
    $("#modal").modal('hide');
    setTimeout(() => {
        $("#sub-modal").modal('show');
    }, 400);
}

$.fn.showFileModal = (config) => {
    let defaultConfig = {
        title: "",
        bodyContent: "",
        dialogClass: "",
        buttonSave: !0
    }
    defaultConfig = $.extend({}, defaultConfig, config);
    $("#modal-file .nv-modal-body").html(defaultConfig.bodyContent);
    $("#modal-file .nv-modal-title").html(defaultConfig.title);
    $("#modal-file").attr("class", "nv-modal").addClass(defaultConfig.dialogClass);
    defaultConfig.buttonSave ? $("#modal-file .btn-save").show() : $("#modal-file .btn-save").hide();
    $("#modal-file").fadeIn('', () => {
        $($.fn.dataTable.tables(true)).DataTable()
            .columns.adjust();
    });
}

$.fn.showPreviewFileModal = (config) => {
    let defaultConfig = {
        title: "",
        bodyContent: "",
        dialogClass: "",
        buttonSave: !0
    }
    defaultConfig = $.extend({}, defaultConfig, config);
    $("#modal-pvfile .nv-modal-body").html(defaultConfig.bodyContent);
    $("#modal-pvfile .nv-modal-title").html(defaultConfig.title);
    $("#modal-pvfile").attr("class", "nv-modal").addClass(defaultConfig.dialogClass);
    defaultConfig.buttonSave ? $("#modal-pvfile .btn-save").show() : $("#modal-pvfile .btn-save").hide();
    $("#modal-pvfile").fadeIn('', () => {
        $($.fn.dataTable.tables(true)).DataTable()
            .columns.adjust();
    });
}

$.fn.closeMainModal = () => {
    $("#modal").fadeOut();
    $('#modal .nv-modal-body').html("");
}

$.fn.closeSubModal = () => {
    $('#sub-modal .nv-modal-body').html("");
    $("#sub-modal").fadeOut();
}

$.fn.closeFileModal = () => {
    $('#modal-file .nv-modal-body').html("");
    $("#modal-file").fadeOut();
}

$.fn.closePreviewFileModal = () => {
    $('#modal-pvfile .nv-modal-body').html("");
    $("#modal-pvfile").fadeOut();
}

$.fn.closeModal = (elmModal) => {
    $(elmModal + ' .nv-modal-body').html("");
    $(elmModal).fadeOut();
}