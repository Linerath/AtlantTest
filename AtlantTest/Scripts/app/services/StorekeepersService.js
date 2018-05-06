(function () {
    'use strict';

    angular
        .module('mainApp')
        .factory('storekeepersService', storekeepersService);

    storekeepersService.$inject = ['$http', '$q'];

    function storekeepersService($http, $q) {
        var service = {};

        service.getStorekeepers = function () {
            return $http.get('/Storekeepers/GetAll');
        };

        service.addStorekeeper = function (storekeeper) {
            var deferred = $q.defer();
            $http.post('/Storekeepers/Add', storekeeper)
                .then(
                    function (response) {
                        deferred.resolve(response.data);
                    }, function (error) {
                        console.log(error);
                        deferred.reject(error);
                    });
            return deferred.promise;
        }

        service.deleteStorekeeper = function (storekeeperId) {
            var deferred = $q.defer();
            $http.post('/Storekeepers/Delete', { storekeeperId: storekeeperId })
                .then(
                function (response) {
                        deferred.resolve(response.data);
                    }, function (error) {
                        console.log(error);
                        deferred.reject(error);
                    });
            return deferred.promise;
        }

        return service;
    }
})();