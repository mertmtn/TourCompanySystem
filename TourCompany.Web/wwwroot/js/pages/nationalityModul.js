function submitForEdit() {
    var nationalityViewModel = {
        Name: $("#Name").val(),
        NationalityId: $("#NationalityId").val(),
        Price: $("#Price").val(),
        IsActive: $("#IsActive").prop('checked')
    };

    $.ajax({
        type: "POST",
        url: "/Nationality/Edit/",
        data: nationalityViewModel,
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
                callback: function () { window.location.href = "/Nationality" }
            }).showToast();
        }
        else {
            $(".modal-body").html(data);
            $(".modal-title").html("Uyruk Güncelle");
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

    var nationalityViewModel = {
        Name: $("#Name").val(),
        Price: $("#Price").val(),
        IsActive: $("#IsActive").prop('checked')
    };

    $.ajax({
        type: "POST",
        url: "/Nationality/Create/",
        data: nationalityViewModel,
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
                callback: function () { window.location.href = "/Nationality" }
            }).showToast();
        }
        else {
            $(".modal-body").html(data);
            $(".modal-title").html("Yeni Uyruk Tanımı");
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
