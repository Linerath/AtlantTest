(function () {
    'use strict';

    angular
        .module('mainApp')
        .controller('detailsCtrl', detailsCtrl);

    detailsCtrl.$inject = ['$scope', 'detailsService'];

    function detailsCtrl($scope, detailsService) {

        getDetails();

        function getDetails() {
            detailsService.getDetails()
                .then(
                    function (response) {
                        $scope.detailsData = JSON.parse(response.data);
                        console.log($scope.detailsData);
                    }, function (error) {
                        console.log(error);
                    });
        }
    }
})();
