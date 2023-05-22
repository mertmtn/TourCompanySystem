
function submitForEdit() {
    var touristViewModel = {
        Name: $("#Name").val(),
        TouristId: $("#TouristId").val(),
        Gender: $("#Gender").val(),
        CountryId: $("#CountryId").val(),
        NationalityId: $("#NationalityId").val(),
        Surname: $("#Surname").val(),
        IsActive: $("#IsActive").prop('checked')
    };

    $.ajax({
        type: "POST",
        url: "/Tourist/Edit/",
        data: touristViewModel,
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
                callback: function () { window.location.href = "/Tourist" }
            }).showToast();
        }
        else {
            $(".modal-body").html(data);
            $(".modal-title").html("Turist Güncelle");
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

    var touristViewModel = {
        Name: $("#Name").val(),
        TouristId: $("#TouristId").val(),
        Gender: $("#Gender").val(),
        CountryId: $("#CountryId").val(),
        NationalityId: $("#NationalityId").val(),
        Surname: $("#Surname").val(),
        IsActive: $("#IsActive").prop('checked')
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
                gravity: "bottom",
                position: "right",
                stopOnFocus: true,
                style: {
                    background: "linear-gradient(to right, #04AA6D, #04AA6D)",
                },
                callback: function () { window.location.href = "/Tourist" }
            }).showToast();
        }
        else {
            $(".modal-body").html(data);
            $(".modal-title").html("Yeni Turist Tanımı");
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





