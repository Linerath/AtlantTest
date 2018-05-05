(function () {
    'use strict';

    angular
        .module('mainApp')
        .controller('storekeepersCtrl', storekeepersCtrl);

    storekeepersCtrl.$inject = ['$scope', 'storekeepersService'];

    function storekeepersCtrl($scope, storekeepersService) {

        $scope.storekeeper = {};

        getStorekeepers();

        function getStorekeepers() {
            storekeepersService.getStorekeepers()
                .then(
                    function (response) {
                        $scope.storekeepersData = response.data;
                        console.log($scope.storekeepersData);
                    }, function (error) {
                        console.log(error);
                    });
        };

        $scope.addStorekeeper = function (storekeeper) {
            storekeepersService.addStorekeeper(storekeeper)
                .then(
                    function (response) {
                        getStorekeepers();
                    }, function (error) {
                        console.log(error);
                    });
        };
    }
})();
