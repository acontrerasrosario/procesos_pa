(function () {
    angular.module('procesos_pa')
        .controller('AddSubjectsController', AddSubjectsController);

    

    AddSubjectsController.$inject = ['$scope', '$http'];
    function AddSubjectsController($scope, $http) {
        $scope.newSubject = {
            Codigo: null,
            Name: null,
            QtyCredits: null,
            AreaId: null
        };
        
        $http.get('/api/areas/GetAreas/').then(
            // Gonna excecute if the server returns no errors
            function (result) {
                $scope.Areas = result.data;
              //  $('#AreaSelect').val();         
            },
            // If request fails or an error occurs server side
            function () {

            })

        $http.get('/api/subjects/getMaterias/').then(
            // Gonna excecute if the server returns no errors
            function (result) {
                $scope.Subjects = result.data;
            },
            // If request fails or an error occurs server side
            function () {

            });

        $scope.Agregar = function () {
            $scope.newSubject.AreaId = $('#areaSelect').val();
            
          
            var DTO = {
                Codigo: $('#codigo').val(),
                Name: $('#name').val(),
                QtyCredits: $('#qntityCr    edito').val(),
                AreaId: $('#areaSelect').val()
            };

            $http.post('/api/Subjects/createSubject', DTO)
                .then(

                function (data, status, headers, config) {

                    alert('SE AGREGO CORRECTAMENTE.')
                    $scope.newSubject = null;
                    $route.reload();
                },
                
                function () {

                    alert('HUBO UN ERROR, FAVOR CONFIRMAR LOS DATOS.')

                }   
                    
                    
            );
        }

    }
}());