(function () {
    'use strict';

    angular
        .module('mainApp')
        .factory('storekeepersService', storekeepersService);

    storekeepersService.$inject = ['$http'];

    function storekeepersService($http) {
        var service = {};
        service.getStorekeepers = function () {
            return $http.get('/Storekeepers/GetAll');
        };
        return service;
    }        
})();