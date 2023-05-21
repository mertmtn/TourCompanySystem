function updateClaimForUser() {

    var userOperationClaimCreateOrUpdateViewModel = {         
        UserId: $("#UserId").val(),
        SelectedClaims: $("#SelectedClaims").val()      
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
            $(".modal-title").html("Kullanıcı Rol Güncellenmesi");
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

 
