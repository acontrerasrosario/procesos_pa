(function () {
    angular.module('procesos_pa')
        .controller('AddTrimesterController', AddTrimesterController);
    AddTrimesterController.$inject = ['$scope','$http'];

    function AddTrimesterController($scope, $http) {
      $scope.newTrimester = {
        Name: null,
        Inicio: null,
        Fin: null
        };


      $http.get('/api/trimestre/GetTrimestres/').then(
          // Gonna excecute if the server returns no errors
          function (result) {

              $scope.Trimestres = result.data;
          },
          // If request fails or an error occurs server side
          function () {

          }
      );



      $scope.Agregar = function () {
          console.log($scope.newTrimester)
        $http.post('/api/trimestre/createTrimestre', $scope.newTrimester)
          .then(
              function(data,status,headers,config){
                alert('SE AGREGO CORRECTAMENTE.')
              },
              function (){
                alert('HUBO UN ERROR, FAVOR CONFIRMAR LOS DATOS');
              }
          );
      };
    };
}());
