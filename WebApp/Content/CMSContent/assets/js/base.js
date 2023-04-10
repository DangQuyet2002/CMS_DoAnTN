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
function showModal() {
    $("#nv-modal").removeClass("xl")
    $("#nv-modal").removeClass("lg")
    $("#nv-modal").fadeIn();
}

function closeModal() {
    $("#nv-modal").fadeOut();
}

$(".nv-modal-close, .btn-close-modal").on("click", function () {
    debugger;
    $(this).closest('.nv-modal').hide();
})


$(function() {
    //set width select 2
    $("span.select2-container").css("width", "100%")
    //xo?a bo? menu "more trong thanh menu"
    $(".nav-link[href='#sidebarMore']").parent().remove()

    let height = $("#navbar-nav").height() + 25;
    if ($("html").attr("data-layout") == 'horizontal') {
        $(".page-content").css("margin-top", `${height}px`)
    }

    $(".change-layout").on("click", function () {
        window.location.reload()
    })
})