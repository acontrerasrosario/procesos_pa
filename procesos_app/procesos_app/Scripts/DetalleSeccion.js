
$(document).on("click", ".open-Modal", function () {
    var myDNI = $(this)[0].id;

    $.ajax({
        url: '/Estudiante/_DetalleSeccion?id=' + myDNI,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            var asd = response;

            $("#IdSeccion").val(asd.ListaSection[0].Id);
            $("#IdNombre").val(asd.ListaSection[0].Name);
            $("#IdTipo").val(asd.ListaSection[0].SecType);
            $("#IdAula").val(asd.ListaSection[0].ClassRoom);
        },
        error: function (data) {
            alert("ERROR");
        }
    });



    //$(".modal-body #DNI").val(myDNI);
});

   