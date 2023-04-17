// loading
function loading() {
    $("#loading").addClass("active");
    //document.getElementById("loading").addClass("active");
}

function offLoading() {
    $("#loading").removeClass("active");
    //document.getElementById("loading").classList.remove("active");
}

// modal
function showModal(element) {
    $(element).fadeIn();
}

function closeModal(element) {
    $(element).fadeOut();
}
$(document).on("click", ".nv-modal-close, .btn-close-modal", function () {
    $(this).closest('.nv-modal').hide();
})


$(function() {
    //set width select 2
    $("span.select2-container").css("width", "100%")
})