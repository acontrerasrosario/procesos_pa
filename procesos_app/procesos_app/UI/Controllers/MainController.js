(function(){
  var app = angular.module("Procesos_PA");

  app.controller('MainController', function($scope,$http){

    var onUserComplete = function(response){
      $scope.user = response.data;
    };

    var onError = function(reason){
      $scope.error = "Could not fetch the user";
    };

    $http.get('/api/users/getstudents/1061111)
    .then(onUserComplete,onError);


    $scope.message = "Hello, Angular!";

  });

}());
