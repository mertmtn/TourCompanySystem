function openModal(url, title) {
    $.get(url, function (data) {
        $(".modal-body").html(data);
        $(".modal-title").html(title);
        $("#staticBackdrop").modal('show');
    });
} 