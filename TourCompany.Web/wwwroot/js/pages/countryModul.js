function submitForEdit() {

    var countryViewModel = {
        Name: $("#Name").val(),
        CountryId: $("#CountryId").val(),
        IsActive: $("#IsActive").prop('checked'),
        __RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val()
    };

    $.ajax({
        type: "POST",
        url: "/Country/Edit/",
        data: countryViewModel,
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
                callback: function () { window.location.href = "/Country" }
            }).showToast();
        } else {
            $(".modal-body").html(data);
            $(".modal-title").html("Ülke Güncelle");
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

    var countryViewModel = {
        Name: $("#Name").val(),
        IsActive: $("#IsActive").prop('checked'),
        __RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val()
    };

    $.ajax({
        type: "POST",
        url: "/Country/Create/",
        data: countryViewModel,
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
                callback: function () { window.location.href = "/Country" }
            }).showToast();
        }
        else {
            $(".modal-body").html(data);
            $(".modal-title").html("Yeni Ülke Tanımı");
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




