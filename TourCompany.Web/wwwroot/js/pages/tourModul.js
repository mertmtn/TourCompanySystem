
function submitForEdit() {
    var tourViewModel = {
        Name: $("#Name").val(),
        TourId: $("#TourId").val(),
        Price: $("#Price").val(),
        IsActive: $("#IsActive").prop('checked'),
        SelectedPlaces: $("#SelectedPlaces").val(),
        TourDate: $("#TourDate").val(),
        GuideId: $("#GuideId").val(),
        __RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val()
    };

    $.ajax({
        type: "POST",
        url: "/Tours/Edit/",
        data: tourViewModel,
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
                callback: function () { window.location.href = "/Tours" }
            }).showToast();
        }
        else {
            $(".modal-body").html(data);
            $(".modal-title").html("Tur Güncelle");
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

    var tourViewModel = {
        Name: $("#Name").val(),
        Price: $("#Price").val(),
        IsActive: $("#IsActive").prop('checked'),
        SelectedPlaces: $("#SelectedPlaces").val(),
        TourDate: $("#TourDate").val(),
        GuideId: $("#GuideId").val(),
        __RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val()
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
                gravity: "bottom",
                position: "right",
                stopOnFocus: true,
                style: {
                    background: "linear-gradient(to right, #04AA6D, #04AA6D)",
                },
                callback: function () { window.location.href = "/Tours" }
            }).showToast();
        }
        else {
            $(".modal-body").html(data);
            $(".modal-title").html("Yeni Tur Tanýmý");
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





