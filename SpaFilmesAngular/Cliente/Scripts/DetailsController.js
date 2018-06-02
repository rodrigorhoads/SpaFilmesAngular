(function (app) {
    var DetailsController = function ($scope, filmeService, $routeParams) {
        var id = $routeParams.id;
        filmeService.getById(id)
            .success(function (data) {
                $scope.filme = data;
            });
        $scope.edit = function () {
            $scope.edit.filme = angular.copy($scope.filme);
        }
    };
    app.controller("DetailsController",DetailsController);
}(angular.module("atFilmes")))