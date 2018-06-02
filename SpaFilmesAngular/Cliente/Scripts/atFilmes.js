(function () {
    var app = angular.module("atFilmes", ["ngRoute"]);
    var config = function ($routeProvider) {
        $routeProvider.when("/list",
            { templateUrl: "/Cliente/Views/list.html" })
            .when("/details/:id",
            { templateUrl: "/Cliente/Views/details.html" })
            .otherwise({ redirectTo: "/list" });
    };
    app.config(config);
    app.constant("filmeApiUrl","/api/filme/");
}());