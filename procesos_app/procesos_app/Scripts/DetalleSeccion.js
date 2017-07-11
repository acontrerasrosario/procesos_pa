
$(document).on("click", ".open-Modal", function () {
    
    var myDNI = $(this)[0].id;

    $.ajax({
        url: '/Estudiante/_DetalleSeccion?id=' + myDNI,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            var asd = response;

            var boton = document.createElement('a');
            boton.type = 'button';
            boton.id = 'Agregar';
            boton.value = 'Agregar';
            boton.href = '#';


            
            var data = [];
            for (var i = 0; i < asd.length; i++) {
                data.push([
                    asd[i].secName, asd[i].materia, asd[i].curso, asd[i].nombreProf, asd[i].horario, boton.onclick,
                ]);
            }

            $(function () {

              

                var table = $('#Prueba').DataTable({
                    data: data,    
                    
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
                
                
                table.destroy();


            });

        },
        error: function (response) {
            alert("ERROR");
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
