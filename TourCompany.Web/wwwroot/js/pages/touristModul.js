function openCreateModal() {
    $.get("/Tourist/Create/", function (data) {
        $(".modal-body").html(data);
        $(".modal-title").html("Yeni Tur Tanımı");
        $("#staticBackdrop").modal('show');
    });
}

function openDetailModal(id) {
    $.get("/Tourist/Details/" + id, function (data, status) {
        $(".modal-body").html(data);
        $(".modal-title").html("Tur Detayı");
        $("#staticBackdrop").modal('show');
    });
}
function openDeleteModal(id) {
    $.get("/Tourist/Delete/" + id, function (data, status) {
        $(".modal-body").html(data);
        $(".modal-title").html("Kaydı silmek istediğinizden emin misiniz?");
        $("#staticBackdrop").modal('show');
    });
}

function openEditModal(id) {
    $.get("/Tourist/Edit/" + id, function (data, status) {
        $(".modal-body").html(data);
        $(".modal-title").html("Tur Güncelle");
        $("#staticBackdrop").modal('show');
    });
}

function btnEdit(id) {
    $.get("/Tourist/Edit/" + id, function (data, status) {
        $(".modal-body").html(data);
        $(".modal-title").html("Tur Güncelle");
        $("#staticBackdrop").modal('show');
    });
}

function submitForEdit() {
    var touristViewModel = {
        Name: $("#Name").val(),
        TouristId: $("#TouristId").val(),
        Price: $("#Price").val(),
        IsActive: $("#IsActive").val()
    };

    $.ajax({
        type: "POST",
        url: "/Tourist/Edit/",
        data: touristViewModel,
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
            callback: function () { window.location.href = "/Tourist" } // Callback after click
        }).showToast();
    });
}


function submitForCreate() {

    var touristViewModel = {
        Name: $("#Name").val(),
        Price: $("#Price").val(),
        IsActive: $("#IsActive").val()
    };

    $.ajax({
        type: "POST",
        url: "/Tourist/Create/",
        data: touristViewModel,
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
                callback: function () { window.location.href = "/Tourist" } // Callback after click
            }).showToast();
        }
        else {
            $(".modal-body").html(data);
            $(".modal-title").html("Yeni Bölge Tanımı");
            $("#staticBackdrop").modal('show');
        }
    });
}





