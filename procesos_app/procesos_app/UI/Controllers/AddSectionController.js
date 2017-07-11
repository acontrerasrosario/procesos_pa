(function () {
    angular.module('procesos_pa')
        .controller('AddSectionController', AddSectionController);

    AddSectionController.$inject = ['$scope', '$http'];

    function AddSectionController($scope, $http) {
        $scope.SeccionNueva = {
            name: null,
            subject: null,
            secType: null,
            trimestre: null,
            classRoom: null
        }


        $http.get('/api/sections/getsectype/')
            .then(

            function (result) {
                $scope.tipoSeccion = result.data;
            },
            function () {

            }
            )

        $http.get('/api/cursos/getcursos/')
            .then(

            function (result) {
                $scope.cursos = result.data;
            },
            function () {

            }

            )


        $('#curso').change(function () {
            
            $http.get('/api/sections/getHorarios?classRoomActual=' + $("#curso").val())
                .then(
                function (result) {
                    $scope.horario = result.data;
                },
                function () {

                }
                )
        });
        

        $http.get('/api/sections/GetActualTrimestre/')
            .then(
            function (result) {
                $scope.TrimestreActual = result.data;
            },
            function () {

            }
            );


        $http.get('/api/subjects/getMaterias/')
            .then(
            function (result) {
                $scope.Materia = result.data;
            },
            function () {

            }

            );
        $http.get('/api/sections/getsecciones/')
            .then(
            function (result) {
                $scope.SeccionesActivas = result.data;
            },
            function () {

            }

                )



        $scope.Agregar = function () {
            var seccionDTO = {
                name: $('#SecName').val(),
                subjectId: $('#Materia').val(),
                secType: $('#TipoSeccion').val(),
                trimester_Id: 1,
                classRoomId: $('#curso').val(),
                horarioId: $('#dia1').val()
            }

            
            console.log(seccionDTO);
            $http.post('/api/sections/crearSeccion/', seccionDTO)
                .then(
                function (data, status, headers, config) {
                    alert('SE AGREGO CORRECTAMENTE.')

                    console.log(data)
                },
                function (result) {
                    console.log(result)
                    alert(result.data.message);
                },
                function () {
                    alert('HUBO UN ERROR, FAVOR CONFIRMAR LOS DATOS');
                }
                );
        };

       


         

    };
}());

