
function submitForEdit() {
    var guideViewModel = {
        Name: $("#Name").val(),
        Surname: $("#Surname").val(),
        PhoneNumber: $("#PhoneNumber").val(),
        Gender: $("#Gender").val(),
        IsActive: $("#IsActive").prop('checked'),
        SelectedLanguages: $("#SelectedLanguages").val(),
        GuideId: $("#GuideId").val()
    };

    $.ajax({
        type: "POST",
        url: "/Guide/Edit/",
        data: guideViewModel,
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
                callback: function () { window.location.href = "/Guide" }
            }).showToast();
        }
        else {
            $(".modal-body").html(data);
            $(".modal-title").html("Rehber Güncelle");
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

    var guideViewModel = {
        Name: $("#Name").val(),
        Surname: $("#Surname").val(),
        PhoneNumber: $("#PhoneNumber").val(),
        Gender: $("#Gender").val(),
        IsActive: $("#IsActive").prop('checked'),
        SelectedLanguages: $("#SelectedLanguages").val(),
    };

    $.ajax({
        type: "POST",
        url: "/Guide/Create/",
        data: guideViewModel,
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
                callback: function () { window.location.href = "/Guide" }
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





