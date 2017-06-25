
    $("#inicioEstudiante").click(function () {
        $.ajax({
            url: '/Estudiante/_Inicio',
            dataType: "html",
            success: function (data) {
                $('#Contenedor').empty();
                $('#Contenedor').html(data);
            },
            error: function (data) {
                alert("ERROR");
            }
        });
    });

    $("#seleccionEstudiante").click(function () {
        $.ajax({
            url: '/Estudiante/_Seleccion',
            dataType: "html",
            success: function (data) {
                $('#Contenedor').empty();
                $('#Contenedor').html(data);
            },
            error: function (data) {
                alert("ERROR");
            }
        });
    });

    $("#programaEstudiante").click(function () {
        $.ajax({
            url: '/Estudiante/_ProgramaAsignatura',
            dataType: "html",
            success: function (data) {
                $('#Contenedor').empty();
                $('#Contenedor').html(data);
            },
            error: function (data) {
                alert("ERROR");
            }
        });
    });

    $("#ofertaAcademicaEstudiante").click(function () {
        $.ajax({
            url: '/Estudiante/_OfertaAcademica',
            dataType: "html",
            success: function (data) {
                $('#Contenedor').empty();
                $('#Contenedor').html(data);
            },
            error: function (data) {
                alert("ERROR");
            }
        });
    });
