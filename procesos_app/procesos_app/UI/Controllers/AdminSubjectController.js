(function () {
    angular.module('procesos_pa')
        .controller('AdminSubjectController', AdminSubjectController);


    AdminSubjectController.$inject = ['$scope', '$http'];
    function AdminSubjectController($scope, $http) {


        $http.get('/api/subjects/GetMaterias/').then(
            // Gonna excecute if the server returns no errors
            function (result) {
                
                $scope.Subjects = result.data;
            },
            // If request fails or an error occurs server side
            function () {

            }
        );

        $http.get('/api/areas/GetAreas/').then(
            // Gonna excecute if the server returns no errors
            function (result) {
                $scope.Areas = result.data;
                //  $('#AreaSelect').val();         
            },
            // If request fails or an error occurs server side
            function () {

            })

        $scope.ver = function (subject) {
            $scope.currSubject = subject;
            $('#areaSelect').val($scope.currSubject.areaid);
        }

        $scope.modificar = function (subject) {

            $scope.ModSubject = subject;
            $scope.ModSubject.areaid = $('#areaSelect').val();
            console.log($scope.ModSubject)

            $http.put('/api/Subjects/ModifySubject', $scope.ModSubject)
                .then(

                function (data, status, headers, config) {

                    alert('SE AGREGO CORRECTAMENTE.')
                    $scope.currSubject = null;
                    $('#areaSelect').val(0);
                },

                function () {

                    alert('HUBO UN ERROR, FAVOR CONFIRMAR LOS DATOS.')

                }
                );

        }


    }




}());