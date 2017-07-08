
$(document).on("click", ".open-Modal", function () {
    
    var myDNI = $(this)[0].id;

    $.ajax({
        url: '/Estudiante/_DetalleSeccion?id=' + myDNI,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            var asd = response;

            var data = [];
            for (var i = 0; i < asd.length; i++) {
                data.push([
                    asd[i].Id, asd[i].Name, asd[i].SecType, asd[i].ClassRoom,

                ]);
            }


            $(function () {
                $('#Prueba').DataTable({
                    data: data
                });

            });

        },
        error: function (data) {
            alert("ERROR");
        }
    });
});

$(document).ready(function () {
    $('#Seleccion').DataTable();
});