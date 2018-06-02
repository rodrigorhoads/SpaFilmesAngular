(function (app) {

    var EditController = function ($scope, filmeService) {
        $scope.isEditable = function () {
            return $scope.edit && $scope.edit.filme;
        }

        $scope.cancel = function () {
            $scope.edit.filme = null;
        }
        $scope.save = function () {
            if ($scope.edit.filme.Id) {
                updateFilme();
            } else {
                createFilme();
            }
        }

        var updateFilme = function () {
            filmeService.update($scope.edit.filme)
                .success(function () {
                    angular.extend($scope.filme, $scope.edit.filme);
                    $scope.edit.filme = null;
                })
        }

        var createFilme = function () {
            filmeService.create($scope.edit.filme).success(function (filme) {
                $scope.filmes.push(filme)
                $scope.edit.filme = null;
            });
        };
    };
    app.controller("EditController", EditController);
}(angular.module("atFilmes")));