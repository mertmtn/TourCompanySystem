function openDetailModal(id) {
    $.get("/Nationality/Details/" + id, function (data, status) {
        $(".modal-body").html(data);
        $(".modal-title").html("Uyruk Detayı");
        $("#staticBackdrop").modal('show');
    });
}
function openDeleteModal(id) {

    $.get("/Nationality/Delete/" + id, function (data, status) {
        $(".modal-body").html(data);
        $(".modal-title").html("Uyruk Silme Onaylama");
        $("#staticBackdrop").modal('show');
    });
}