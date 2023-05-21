function openCreateModal() {
    $.get("/Nationality/Create/", function (data) {
        $(".modal-body").html(data);
        $(".modal-title").html("Yeni Uyruk Tanımı");
        $("#staticBackdrop").modal('show');
    });
}

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
        $(".modal-title").html("Kaydı silmek istediğinizden emin misiniz?");
        $("#staticBackdrop").modal('show');
    });
}

function openEditModal(id) {
    $.get("/Nationality/Edit/" + id, function (data, status) {
        $(".modal-body").html(data);
        $(".modal-title").html("Uyruk Güncelle");
        $("#staticBackdrop").modal('show');
    });
}

function btnEdit(id) {
    $.get("/Nationality/Edit/" + id, function (data, status) {
        $(".modal-body").html(data);
        $(".modal-title").html("Uyruk Güncelle");
        $("#staticBackdrop").modal('show');
    });
}

function submitForEdit() {
    var nationalityViewModel = {
        Name: $("#Name").val(),
        NationalityId: $("#NationalityId").val(),
        Price: $("#Price").val(),
        IsActive: $("#IsActive").val()
    };

    $.ajax({
        type: "POST",
        url: "/Nationality/Edit/",
        data: nationalityViewModel,
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
            callback: function () { window.location.href = "/Nationality" } // Callback after click
        }).showToast();
    });
}


function submitForCreate() {

    var nationalityViewModel = {
        Name: $("#Name").val(),
        Price: $("#Price").val(),
        IsActive: $("#IsActive").val()
    };

    $.ajax({
        type: "POST",
        url: "/Nationality/Create/",
        data: nationalityViewModel,
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
                callback: function () { window.location.href = "/Nationality" } // Callback after click
            }).showToast();
        }
        else {
            $(".modal-body").html(data);
            $(".modal-title").html("Yeni Bölge Tanımı");
            $("#staticBackdrop").modal('show');
        }
    });
}





