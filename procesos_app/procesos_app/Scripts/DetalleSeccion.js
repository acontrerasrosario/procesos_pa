
$(document).on("click", ".open-Modal", function () {
    var myDNI = $(this)[0].id;

    $.ajax({
        url: '/Estudiante/_DetalleSeccion?id=' + myDNI,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            var asd = response;
        },
        error: function (data) {
            alert("ERROR");
        }
    });



    //$(".modal-body #DNI").val(myDNI);
});

   