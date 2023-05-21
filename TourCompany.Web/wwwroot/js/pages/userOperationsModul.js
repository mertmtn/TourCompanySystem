function submitForEdit() {

    var userForRegisterDto = {
        FirstName: $("#FirstName").val(),
        LastName: $("#LastName").val(),
        MaidenName: $("#MaidenName").val(),
        Email: $("#Email").val(),
        Id: $("#Id").val(),
        IsActive: $("#IsActive").val(),
        Password: $("#Password").val()        
    };

    $.ajax({
        type: "POST",
        url: "/User/Edit/",
        data: userForRegisterDto,


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
            callback: function () { window.location.href = "/User" } // Callback after click
        }).showToast();

    });
}



function submitForCreate() {

    var userForRegisterDto = {
        FirstName: $("#FirstName").val(),
        LastName: $("#LastName").val(),
        MaidenName: $("#MaidenName").val(),
        Email: $("#Email").val(),
        Id: $("#Id").val(),
        IsActive: $("#IsActive").val()
    };

    $.ajax({
        type: "POST",
        url: "/User/Register/",
        data: userForRegisterDto,
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
                callback: function () { window.location.href = "/User" } // Callback after click
            }).showToast();
        }
        else {
            $(".modal-body").html(data);
            $(".modal-title").html("Yeni Ülke Tanýmý");
            $("#staticBackdrop").modal('show');
        }
    });
}
