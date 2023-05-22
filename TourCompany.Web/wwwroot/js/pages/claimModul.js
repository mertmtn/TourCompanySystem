function updateClaimForUser() {

    var userOperationClaimCreateOrUpdateViewModel = {         
        UserId: $("#UserId").val(),
        SelectedClaims: $("#SelectedClaims").val(),
        __RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val()
    };

    $.ajax({
        type: "POST",
        url: "/User/UpdateClaimForUser/",
        data: userOperationClaimCreateOrUpdateViewModel,


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
            $(".modal-title").html("Kullanıcı Rolü Güncelle");
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

    var claimViewModel = {
        Name: $("#Name").val(),
        __RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val()
    };

    $.ajax({
        type: "POST",
        url: "/Claim/Create/",
        data: claimViewModel,
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
                callback: function () { window.location.href = "/Claim" }
            }).showToast();
        }
        else {
            $(".modal-body").html(data);
            $(".modal-title").html("Yeni Rol Tanımı");
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