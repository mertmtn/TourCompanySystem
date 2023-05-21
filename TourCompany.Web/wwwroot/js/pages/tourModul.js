function openCreateModal() {
    $.get("/Tours/Create/", function (data) {
        $(".modal-body").html(data);
        $(".modal-title").html("Yeni Tur Tanýmý");
        $("#staticBackdrop").modal('show');
    });
}

function openDetailModal(id) {
    $.get("/Tours/Details/" + id, function (data, status) {
        $(".modal-body").html(data);
        $(".modal-title").html("Tur Detayý");
        $("#staticBackdrop").modal('show');
    });
}
function openDeleteModal(id) {
    $.get("/Tours/Delete/" + id, function (data, status) {
        $(".modal-body").html(data);
        $(".modal-title").html("Kaydý silmek istediðinizden emin misiniz?");
        $("#staticBackdrop").modal('show');
    });
}

function openEditModal(id) {
    $.get("/Tours/Edit/" + id, function (data, status) {
        $(".modal-body").html(data);
        $(".modal-title").html("Tur Güncelle");
        $("#staticBackdrop").modal('show');
    });
}

function btnEdit(id) {
    $.get("/Tours/Edit/" + id, function (data, status) {
        $(".modal-body").html(data);
        $(".modal-title").html("Tur Güncelle");
        $("#staticBackdrop").modal('show');
    });
}

function submitForEdit() {
    var tourViewModel = {
        Name: $("#Name").val(),
        TourId: $("#TourId").val(),
        Price: $("#Price").val(),
        IsActive: $("#IsActive").val()
    };

    $.ajax({
        type: "POST",
        url: "/Tours/Edit/",
        data: tourViewModel,
        encode: true,
    }).done(function (data) {
        $("#staticBackdrop").modal('hide');
        Toastify({
            text: data.message,
            duration: 1500,
            close: true,
            gravity: "top", // `top` or `bottom`
            position: "left", // `left`, `center` or `right`
            stopOnFocus: true, // Prevents dismissing of toast on hover
            style: {
                background: "linear-gradient(to right, #00b09b, #96c93d)",
            },
            callback: function () { window.location.href = "/Tours" } // Callback after click
        }).showToast();
    });
}


function submitForCreate() {

    var tourViewModel = {
        Name: $("#Name").val(),
        Price: $("#Price").val(),
        IsActive: $("#IsActive").val()
    };

    $.ajax({
        type: "POST",
        url: "/Tours/Create/",
        data: tourViewModel,
        encode: true,
    }).done(function (data) {
        if (data.success) {
            $("#staticBackdrop").modal('hide');
            Toastify({
                text: data.message,
                duration: 1500,
                close: true,
                gravity: "top", // `top` or `bottom`
                position: "left", // `left`, `center` or `right`
                stopOnFocus: true, // Prevents dismissing of toast on hover
                style: {
                    background: "linear-gradient(to right, #00b09b, #96c93d)",
                },
                callback: function () { window.location.href = "/Tours" } // Callback after click
            }).showToast();
        }
        else {
            $(".modal-body").html(data);
            $(".modal-title").html("Yeni Bölge Tanýmý");
            $("#staticBackdrop").modal('show');
        }
    });
}





