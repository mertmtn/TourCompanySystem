function openCreateModal() {
    $.get("/Language/Create/", function (data) {
        $(".modal-body").html(data);
        $(".modal-title").html("Yeni Dil Tanımı");
        $("#staticBackdrop").modal('show');
    });
}

function openDetailModal(id) {
    $.get("/Language/Details/" + id, function (data, status) {
        $(".modal-body").html(data);
        $(".modal-title").html("Dil Detayı");
        $("#staticBackdrop").modal('show');
    });
}
function openDeleteModal(id) {
    $.get("/Language/Delete/" + id, function (data, status) {
        $(".modal-body").html(data);
        $(".modal-title").html("Kaydı silmek istediğinizden emin misiniz?");
        $("#staticBackdrop").modal('show');
    });
}

function openEditModal(id) {
    $.get("/Language/Edit/" + id, function (data, status) {
        $(".modal-body").html(data);
        $(".modal-title").html("Dil Güncelle");
        $("#staticBackdrop").modal('show');
    });
}

function btnEdit(id) {
    $.get("/Language/Edit/" + id, function (data, status) {
        $(".modal-body").html(data);
        $(".modal-title").html("Dil Güncelle");
        $("#staticBackdrop").modal('show');
    });
}

function submitForEdit() {
    var languageViewModel = {
        Name: $("#Name").val(),
        LanguageId: $("#LanguageId").val(),
        Price: $("#Price").val(),
        IsActive: $("#IsActive").val()
    };

    $.ajax({
        type: "POST",
        url: "/Language/Edit/",
        data: languageViewModel,
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
            callback: function () { window.location.href = "/Language" } // Callback after click
        }).showToast();
    });
}


function submitForCreate() {

    var languageViewModel = {
        Name: $("#Name").val(),
        Price: $("#Price").val(),
        IsActive: $("#IsActive").val()
    };

    $.ajax({
        type: "POST",
        url: "/Language/Create/",
        data: languageViewModel,
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
                callback: function () { window.location.href = "/Language" } // Callback after click
            }).showToast();
        }
        else {
            $(".modal-body").html(data);
            $(".modal-title").html("Yeni Bölge Tanımı");
            $("#staticBackdrop").modal('show');
        }
    });
}





