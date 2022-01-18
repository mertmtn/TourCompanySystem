function openDetailModal(id) {
    $.get("/Language/Details/" + id, function (data, status) {
        $(".modal-body").html(data);
        $(".modal-title").html("Yabancı Dil Detayı");
        $("#staticBackdrop").modal('show');
    });
}
function openDeleteModal(id) {

    $.get("/Language/Delete/" + id, function (data, status) {
        $(".modal-body").html(data);
        $(".modal-title").html("Yabancı Dil Silme Onaylama");
        $("#staticBackdrop").modal('show');
    });
}