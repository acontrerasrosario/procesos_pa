(function () {
    var context = angular.module("SisAcademicoPA",
        //Dependencies
        ['ngRoute']);
    context.config(function ($routeProvider, $locationProvider) {
        $locationProvider.hashPrefix('');
        $routeProvider
        .when("/Inicio",
        {
            templateUrl: '/UI/Templates/Inicio.html',
        })
        .when("/",
        {
            templateUrl: '/UI/Templates/Inicio.html',
        })
        .when("/AddMenuOption",
        {
            templateUrl: '/UI/Templates/Sys/AddMenuOption.html',
        })
            /// UI / Templates / Users / AddUser.html
        .when("/AddUSer",
        {
            templateUrl: '/UI/Templates/Users/AddUser.html',
        })
        .when("/AdministrarUsuarios",
        {
            templateUrl: '/UI/Templates/Users/AdminUsers.html',
        })
        .when("/AddAsignature",
        {
            templateUrl: '/UI/Templates/Asignatures/AddAsignature.html',
        })
        .when("/adminAsignatures",
        {
            templateUrl: '/UI/Templates/Asignatures/AdminAsignatures.html',
        })
        .when("/addMajor",
        {
            templateUrl: '/UI/Templates/Majors/AddMajors.html',
        })
        .when("/UsersDetails/:userId",
        {
            templateUrl: '/UI/Templates/Users/UsersDetails.html',
        })
        .when("/addArea",
        {
            templateUrl: '/UI/Templates/Areas/AddArea.html',
        })
        .otherwise({ redirectTo: '/404' });

    });
    context.run(['$http', function ($http) {
        var tkn = localStorage.cred;
        if (!tkn) {
            window.location.replace('/Login');
        }
        else {
            var coded = btoa(tkn);
            $http.defaults.headers.common.Authorization = coded;
             console.log($http.defaults.headers.common.Authorization);
        }

    }]);
}());
