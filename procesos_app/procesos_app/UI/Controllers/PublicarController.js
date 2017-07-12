(function(){

  angular.module('procesos_pa')
      .controller('PublicarController', PublicarController);

      PublicarController.$inject = ['$scope', '$http'];
      function PublicarController($scope, $http) {
          $scope.Publicar = {
              EstudianteId:null,
              SeccionId: null,
              FinalScore:null,
              Status:null,
              Calificacion: null
          };


          $http.get('/api/publicar/GetSeccion/')
            .then(
                function(result){

                  $scope.Secciones = result.data;
                  console.log($scope.Secciones);
                },
                function(){
                }
            );

          $('#seccion').change(function(){

              $http.get('/api/Publicar/getStudents?SeccionId='+ $('#seccion').val())
                .then(
                    function(result){
                      $scope.estudiantes = result.data;
                      console.log($scope.estudiantes);
                    },
                    function(){

                    });

          });





      };



}());
