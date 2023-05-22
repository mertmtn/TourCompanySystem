
function submitForEdit() {
    var languageViewModel = {
        Name: $("#Name").val(),
        LanguageId: $("#LanguageId").val(),
        IsActive: $("#IsActive").prop('checked'),
         __RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val()
    };

    $.ajax({
        type: "POST",
        url: "/Language/Edit/",
        data: languageViewModel,
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
            callback: function () { window.location.href = "/Language" }
        }).showToast();
        }
        else {
            $(".modal-body").html(data);
            $(".modal-title").html("Dil Güncelle");
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

    var languageViewModel = {
        Name: $("#Name").val(),
        IsActive: $("#IsActive").prop('checked'),
        __RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val()
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
                gravity: "bottom",
                position: "right",
                stopOnFocus: true, 
                style: {
                    background: "linear-gradient(to right, #04AA6D, #04AA6D)",
                },
                callback: function () { window.location.href = "/Language" }
            }).showToast();
        }
        else {
            $(".modal-body").html(data);
            $(".modal-title").html("Yeni Dil Tanımı");
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





