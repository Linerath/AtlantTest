(function () {
    'use strict';

    angular
        .module('mainApp')
        .factory('detailsService', detailsService);

    detailsService.$inject = ['$http'];

    function detailsService($http) {
        var service = {};
        service.getDetails = function () {
            return $http.get('/Details/GetAll');
        };
        return service;
    }
})();