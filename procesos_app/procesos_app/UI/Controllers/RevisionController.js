(function () {


  angular.module('procesos_pa')
      .controller('RevisionController', RevisionController);

      RevisionController.$inject = ['$scope', '$http'];
      function RevisionController($scope, $http) {


          $http.get('/api/revision/getSecciones/')
              .then(

              function (result) {

                  $scope.Seccion = result.data;
              
              },
              function(){

              }
          );

          $scope.ver= function(){
              console.log($scope.Seccion);
          }



      }



}());
