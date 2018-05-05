(function () {
    'use strict';

    angular
        .module('mainApp')
        .controller('storekeepersCtrl', storekeepersCtrl);

    storekeepersCtrl.$inject = ['$scope', 'storekeepersService'];

    function storekeepersCtrl($scope, storekeepersService) {

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
        }
    }
})();
