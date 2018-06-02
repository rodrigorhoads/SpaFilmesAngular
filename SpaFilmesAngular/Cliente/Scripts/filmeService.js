(function (app) {
    var filmeService = function ($http, filmeApiUrl) {
        var getAll = function () {
            return $http.get(filmeApiUrl);
        };
        var getById = function (id) {
            return $http.get(filmeApiUrl + id);
        };

        var update = function (filme) {
            return $http.put(filmeApiUrl + filme.Id, filme);
        };

        var create = function (filme) {
            return $http.post(filmeApiUrl, filme);
        };
        var destroy = function (filme) {
            return $http.delete(filmeApiUrl+filme.Id);
        };

        return {
            getAll: getAll,
            getById: getById,
            update: update,
            create: create,
            delete: destroy
        };
    };
    app.factory("filmeService", filmeService);
}(angular.module("atFilmes")));