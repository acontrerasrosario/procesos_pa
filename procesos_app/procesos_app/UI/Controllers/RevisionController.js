(function () {


  angular.module('procesos_pa')
      .controller('RevisionController', RevisionController);

      RevisionController.$inject = ['$scope', '$http'];
      function RevisionController($scope, $http) {
          $scope.NewSolicitud ={

                    StudentId :null,
                    SectionId :null,
                    SolicitudStudiante :null,
                    AreaId :null,
                    SolicidudArea :null,
                    Cambio :null,
                    TeacherId :null,
                    Finished :null,
                    Motivo : null
          };

          $http.get('/api/revision/GetRevisionHechaEst/')
            .then(
                function(result){
                    $scope.RevisionEstablecida = result.data;
                },
                function(){

                }
            );


          $http.get('/api/revision/getSecciones/')
              .then(

              function (result) {

                  $scope.Seccion = result.data;

              },
              function(){

              }
          );

          $scope.cancelar = function(deleteRev){
              $scope.BorrarSolicitud=deleteRev;
            console.log($scope.BorrarSolicitud);

                $http.get('/api/revision/CancelarRevision?id='+ $scope.BorrarSolicitud.revisionId)
                .then(
                  function(data, status, headers, config) {
                      alert('HA SIDO ELIMINADO CORRECTAMENTE');
                        $scope.NewSolicitud=null;
                  },
                  function(){
                      alert('HUBO UN ERROR');
                  }

                );
          };


          $scope.solicitar = function (s){

            $scope.NewSolicitud.StudentId = s.studentId;
            $scope.NewSolicitud.SectionId =s.id;
            $scope.NewSolicitud.SolicitudStudiante = true;
            $scope.NewSolicitud.AreaId = s.areaId;
            $scope.NewSolicitud.SolicidudArea = false;
            $scope.NewSolicitud.Cambio = false;
            $scope.NewSolicitud.TeacherId = s.teacherId;
            $scope.NewSolicitud.Finished = false;
            $scope.NewSolicitud.Motivo = $('#motivo').val();

              console.log($scope.NewSolicitud);

            $http.post('/api/Revision/CrearSolicitud/',$scope.NewSolicitud)
              .then (
                function (data, status, headers, config) {

                    alert('SE AGREGO CORRECTAMENTE.')
                    $scope.NewSolicitud = null;

                },
                  function(){

                  }
            );

          };

          $scope.ver= function(){
              console.log($scope.Seccion);
          }



      }



}());
