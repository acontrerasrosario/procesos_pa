(function () {
    angular.module('procesos_pa')
        .controller('ProfesorAutorizacionController', ProfesorAutorizacionController);
    ProfesorAutorizacionController.$inject = ['$scope', '$http'];

    function ProfesorAutorizacionController($scope, $http) {
        $scope.nuevaAutorizacion = {
            ProfesorId: null,
            MateriaId: null
        };


        $http.get('/api/users/GetTeachers/').then(
            // Gonna excecute if the server returns no errors
            function (result) {

                $scope.Profesores = result.data;
            },
            // If request fails or an error occurs server side
            function () {

            }
        );

        $('#profesor').change(function () {
           
            $http.get('/api/ValidarProfesor/Validacion?profesorid=' + $('#profesor').val())
                .then(
                // Gonna excecute if the server returns no errors
                function (result) {

                    $scope.Materias = result.data;
                },
                // If request fails or an error occurs server side
                function () {

                }
            );
        });

       


        $http.get('/api/validarProfesor/getValidacion/').then(
            function (result) {
                $scope.autorizaciones = result.data;
            },
            function () {

            }


        )


        $scope.eliminar = function (validacion) {
            $scope.valDelete = validacion;

            $http.get('/api/validarProfesor/DeleteValidacion?validacionId='+ $scope.valDelete.id)
                .then(
                function (data, status, headers, config) {
                    alert('HA SIDO ELIMINADO CORRECTAMENTE')
                    
                },
                function () {
                    alert('HUBO UN ERROR')
                }


                )
        }


        $scope.Agregar = function () {
            $scope.nuevaAutorizacion.ProfesorId = $('#profesor').val();
            $scope.nuevaAutorizacion.MateriaId = $('#materia').val();
            console.log($scope.nuevaAutorizacion)
            $http.post('/api/ValidarProfesor/CrearValidacion', $scope.nuevaAutorizacion)
                .then(
                function (data, status, headers, config) {
                    alert('SE AGREGO CORRECTAMENTE.')
                },
                function () {
                    alert('HUBO UN ERROR, FAVOR CONFIRMAR LOS DATOS');
                }
                );
        };
        

    };
}());
