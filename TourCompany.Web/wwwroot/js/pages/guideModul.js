
function submitForEditPlace() {
    var placeViewModel = {
        Name: $("#Name").val(),
        PlaceId: $("#PlaceId").val(),
        Price: $("#Price").val(),
        IsActive: $("#IsActive").val()
    };

    $.ajax({
        type: "POST",
        url: "/Guide/Edit/",
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
            callback: function () { window.location.href = "/Guide" } // Callback after click
        }).showToast();
    }).fail(function (jqXHR, textStatus) {
        if (jqXHR.status === 400) {
            console.log(jqXHR.responseText)
        }
        else if (jqXHR.status === 500) {
            console.error(jqXHR.responseText)
        }
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
        url: "/Guide/Create/",
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
                callback: function () { window.location.href = "/Guide" } // Callback after click
            }).showToast();
        } 
        else {
            $(".modal-body").html(data);
            $(".modal-title").html("Yeni Rehber Tanımı");
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





