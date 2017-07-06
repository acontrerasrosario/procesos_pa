var project = angular.module('procesos_pa', ['ngRoute']);

project.controller('LandingPageController', LandingPageController);

var configFunction = function ($routeProvider) {
  $routeProvider.
  when('/routeOne', {
    templateUrl: 'Home/one'
  })
  .when('/routeTwo', {
    templateUrl: function (params) {return '/Home/two?donuts=' + params.donuts;}
  })
  .when('/routeThree', {
    templateUrl: 'Home/three'
  });
}
configFunction.$inject = ['$routeProvider'];
project.config(configFunction);
