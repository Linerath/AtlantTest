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

        service.getDetail = function (detailId) {
            return $http.get('/Details/Get?detailId=' + detailId);
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
        };

        service.markDetailDeleted = function (detailId) {
            var deferred = $q.defer();
            $http.post('/Details/MarkDeleted', { detailId: detailId })
                .then(
                    function (response) {
                        deferred.resolve(response.data);
                    }, function (error) {
                        deferred.reject(error);
                    });
            return deferred.promise;
        };

        service.deleteDetail = function (detailId) {
            var deferred = $q.defer();
            $http.post('/Details/Delete', { detailId: detailId })
                .then(
                    function (response) {
                        deferred.resolve(response.data);
                    }, function (error) {
                        deferred.reject(error);
                    });
            return deferred.promise;
        };

        service.updateDetail = function (detail) {
            var deferred = $q.defer();
            $http.post('/Details/Update', detail)
                .then(
                    function (response) {
                        deferred.resolve(response.data);
                    }, function (error) {
                        deferred.reject(error);
                    });
            return deferred.promise;
        };

        service.addDetailQuantity = function (detailId, quantity) {
            var deferred = $q.defer();
            $http.post('/Details/AddQuantity', { detailId: detailId, quantity: quantity })
                .then(
                    function (response) {
                        deferred.resolve(response.data);
                    }, function (error) {
                        deferred.reject(error);
                    });
            return deferred.promise;
        };

        return service;
    }
})();