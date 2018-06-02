(function (app) {
    //$inject se colocado na frente de uma funcao permite que o arquivo seja minificado sem problemas (EX:ListController.$inject=["$scope","$http"])
    var ListController = function ($scope,filmeService) {
        //variaveis usadas aqui podem ser usadas onde a diretiva do controller for declarada nas views
        filmeService.getAll().success(function (data) {
            $scope.filmes = data;
        });

        $scope.create = function () {
            $scope.edit = {
                filme: {
                    Titulo: "",
                    Duracao: 0,
                    AnoLancamento: new Date().getFullYear()
                }
            };
        };

        $scope.delete = function (filme) {
            filmeService.delete(filme)
                .success(function () {
                    removeFilmePorId(filme.Id);
                });
        };

        var removeFilmePorId = function (id) {
            for (var i = 0; i < $scope.filmes.length; i++) {
                if ($scope.filmes[i].Id==id) {
                    $scope.filmes.splice(i, 1);
                    break;
                }
            }
        };
        
    };//refencia para o controller
    app.controller("ListController", ListController);//registro do controller

}(angular.module("atFilmes")));