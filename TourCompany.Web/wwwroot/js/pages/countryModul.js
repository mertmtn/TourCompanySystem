function openDetailModal(id) {
    $.get("/Country/Details/" + id, function (data, status) {
        $(".modal-body").html(data);
        $(".modal-title").html("Ülke Detayı");
        $("#staticBackdrop").modal('show');
    });
}
function openDeleteModal(id) {

    $.get("/Country/Delete/" + id, function (data, status) {
        $(".modal-body").html(data);
        $(".modal-title").html("Ülke Silme Onaylama");
        $("#staticBackdrop").modal('show');
    });
}