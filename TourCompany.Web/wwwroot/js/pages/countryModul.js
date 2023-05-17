function openDetailModal(id) {
    $.get("/Country/Details/" + id, function (data, status) {
        $(".modal-body").html(data);
        $(".modal-title").html("Ülke Detayı");
        $("#staticBackdrop").modal('show');
    });
}
function openDeleteModal(id) {

    $.get("/Country/Delete/" + id, function (data, status) {
        $(".modal-body").html(data);
        $(".modal-title").html("Ülke Silme Onaylama");
        $("#staticBackdrop").modal('show');
    });
}

function openEditModal(id) {
    $.get("/Country/Edit/" + id, function (data, status) {
        $(".modal-body").html(data);
        $(".modal-title").html("Ülke Güncelle");
        $("#staticBackdrop").modal('show');
    });
}



function btnCountryEdit(id) {
    $.get("/Country/Edit/" + id, function (data, status) {
        $(".modal-body").html(data);
        $(".modal-title").html("Ülke Güncelle");
        $("#staticBackdrop").modal('show');
    });
}
function submitForEditCountry() {

    var countryViewModel = {
        Name: $("#Name").val(),
        CountryId: $("#CountryId").val(),
        IsActive: $("#IsActive").val()
    }; 

    $.ajax({
        type: "POST",
        url: "/Country/Edit/",
        data: countryViewModel,
       
      
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
            callback: function () { window.location.href ="/Country" } // Callback after click
        }).showToast();

    });
}








