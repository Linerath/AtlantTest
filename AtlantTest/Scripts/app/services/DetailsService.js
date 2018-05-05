(function () {
    'use strict';

    angular
        .module('mainApp')
        .factory('detailsService', detailsService);

    detailsService.$inject = ['$http', '$q'];

    function detailsService($http, $q) {
        var service = {};

        service.getDetails = function () {
            return $http.get('/Details/GetAll');
        };

        service.addDetail = function (detail) {
            var deferred = $q.defer();
            $http.post('/Details/Add', detail)
                .then(
                    function (response) {
                        deferred.resolve(response.data);
                    }, function (error) {
                        deferred.reject(error);
                    });
            return deferred.promise;
        }

        return service;
    }
})();