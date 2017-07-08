(function () {

    var project = angular.module('procesos_pa', ['ngRoute']);

    //project.controller('AddSubjectsController', AddSubjectsController);


    var configFunction = function ($routeProvider) {
        $routeProvider.
            when('/ModificarSubject/:subjectId', {
                templateUrl: '/UI/Template/ModSubject.html',
            })
           
    }

    configFunction.$inject = ['$routeProvider'];
    project.config(configFunction);


}());


