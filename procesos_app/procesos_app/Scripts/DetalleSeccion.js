
$(document).on("click", ".open-Modal", function () {

    var myDNI = $(this)[0].id;

    $.ajax({
        url: '/Estudiante/_DetalleSeccion?id=' + myDNI,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            var asd = response;
            $('#TablaSecciones tbody').empty();

            var data = [];
            $.each(asd, function (key, value) {

                var currentRow =
                    '<tbody>' +
                    '<tr>' +
                    '<td>' + value.secName + '</td>' +
                    '<td>' + value.materia + '</td>' +
                    '<td>' + value.curso + '</td>' +
                    '<td>' + value.nombreProf + '</td>' +
                    '<td>' + value.horario + '</td>' +
                    '<td>' + "<a onclick='Onclic(" + value.secId + ")' id='" + value.secId + "'class='btn btn-default' >Agregar</a >" + '</td>'
                    + '</tr>' + '</tbody>';
                data.push(currentRow);

            });
            var datasource = data.join('');
            $('#TablaSecciones').append(datasource);


        },
        error: function (response) {
            alert("ERROR EN EL SERVIDOR");
        }
    });
});


$(document).ready(function () {
    $('#Seleccion').DataTable({
        "language": {

            "sProcessing": "Procesando...",
            "sLengthMenu": "Mostrar _MENU_ registros",
            "sZeroRecords": "No se encontraron resultados",
            "sEmptyTable": "Ningún dato disponible en esta tabla",
            "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
            "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
            "sInfoPostFix": "",
            "sSearch": "Buscar:",
            "sUrl": "",
            "sInfoThousands": ",",
            "sLoadingRecords": "Cargando...",
            "oPaginate": {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            }
        }
    });
});

function Onclic(id) {
    $.ajax({
        url: '/Estudiante/AgregarSeccion?id=' + id,
        type: 'POST',
        contentType: 'application/json',

        error: function () {
            alert("ERROR EN EL SERVIDOR");
        }
    });
}

$(document).on("click", ".borrar", function () {

    var myBorrar = $(this)[0].id;

    $.ajax({
        url: '/Estudiante/BorrarSeccion?id=' + myBorrar,
        type: 'POST',
        contentType: 'application/json',

        error: function () {
            alert("ERROR EN EL SERVIDOR");
        }
    });

});