function submitForEdit() {

    var registerViewModel = {
        FirstName: $("#FirstName").val(),
        LastName: $("#LastName").val(),
        MaidenName: $("#MaidenName").val(),
        Email: $("#Email").val(),
        Id: $("#Id").val(),
        IsActive: $("#IsActive").prop('checked'),
        __RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val()
    };

    $.ajax({
        type: "POST",
        url: "/User/Edit/",
        data: registerViewModel,
        encode: true,
    }).done(function (data) {
        if (data.success) {
            $("#staticBackdrop").modal('hide');
            Toastify({
                text: data.message,
                duration: 1500,
                close: true,
                gravity: "bottom",
                position: "right",
                stopOnFocus: true,
                style: {
                    background: "linear-gradient(to right, #04AA6D, #04AA6D)",
                },
                callback: function () { window.location.href = "/User" }
            }).showToast();
        }
        else {
            $(".modal-body").html(data);
            $(".modal-title").html("Kullanıcı Güncelleme");
            $("#staticBackdrop").modal('show');
        }
    }).fail(function (jqXHR, textStatus) {
        if (jqXHR.status === 400) {
            console.log(jqXHR.responseText)
        }
        else if (jqXHR.status === 500) {
            console.error(jqXHR.responseText)
        }
    });
}

function submitForCreate() {

    var registerViewModel = {
        FirstName: $("#FirstName").val(),
        LastName: $("#LastName").val(),
        MaidenName: $("#MaidenName").val(),
        Email: $("#Email").val(),
        Id: $("#Id").val(),
        IsActive: $("#IsActive").prop('checked'),
        __RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val(),
        Password: $("#Password").val()
    };

    $.ajax({
        type: "POST",
        url: "/User/Create/",
        data: registerViewModel,
        encode: true,
    }).done(function (data) {
        if (data.success) {
            $("#staticBackdrop").modal('hide');
            Toastify({
                text: data.message,
                duration: 1500,
                close: true,
                gravity: "bottom",
                position: "right",
                stopOnFocus: true,
                style: {
                    background: "linear-gradient(to right, #04AA6D, #04AA6D)",
                },
                callback: function () { window.location.href = "/User" }
            }).showToast();
        }
        else {
            $(".modal-body").html(data);
            $(".modal-title").html("Yeni Kullanıcı Tanımı");
            $("#staticBackdrop").modal('show');
        }
    }).fail(function (jqXHR, textStatus) {
        if (jqXHR.status === 400) {
            console.log(jqXHR.responseText)
        }
        else if (jqXHR.status === 500) {
            console.error(jqXHR.responseText)
        }
    });
}
