function openCreateModal() {
    $.get("/Place/Create/", function (data) {
        $(".modal-body").html(data);
        $(".modal-title").html("Yeni Bölge Tanımı");
        $("#staticBackdrop").modal('show');
    });
}

function openDetailModal(id) {
    $.get("/Place/Details/" + id, function (data, status) {
        $(".modal-body").html(data);
        $(".modal-title").html("Bölge Detayı");
        $("#staticBackdrop").modal('show');
    });
}
function openDeleteModal(id) {
    $.get("/Place/Delete/" + id, function (data, status) {
        $(".modal-body").html(data);
        $(".modal-title").html("Kaydı silmek istediğinizden emin misiniz?");
        $("#staticBackdrop").modal('show');
    });
}

function openEditModal(id) {
    $.get("/Place/Edit/" + id, function (data, status) {
        $(".modal-body").html(data);
        $(".modal-title").html("Bölge Güncelle");
        $("#staticBackdrop").modal('show');
    });
}

function btnPlaceEdit(id) {
    $.get("/Place/Edit/" + id, function (data, status) {
        $(".modal-body").html(data);
        $(".modal-title").html("Bölge Güncelle");
        $("#staticBackdrop").modal('show');
    });
}

function submitForEdit() {
    var placeViewModel = {
        Name: $("#Name").val(),
        PlaceId: $("#PlaceId").val(),
        Price: $("#Price").val(),
        IsActive: $("#IsActive").val()
    };

    $.ajax({
        type: "POST",
        url: "/Place/Edit/",
        data: placeViewModel,
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
            callback: function () { window.location.href = "/Place" } // Callback after click
        }).showToast();
    });
}


function submitForCreatePlace() {

    var placeViewModel = {
        Name: $("#Name").val(),
        Price: $("#Price").val(),
        IsActive: $("#IsActive").val()
    };

    $.ajax({
        type: "POST",
        url: "/Place/Create/",
        data: placeViewModel,
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
                callback: function () { window.location.href = "/Place" } // Callback after click
            }).showToast();
        } 
        else {
            $(".modal-body").html(data);
            $(".modal-title").html("Yeni Bölge Tanımı");
            $("#staticBackdrop").modal('show');
        }
    });
}





