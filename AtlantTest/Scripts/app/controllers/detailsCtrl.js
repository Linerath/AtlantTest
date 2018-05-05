(function () {
    'use strict';

    angular
        .module('mainApp')
        .controller('detailsCtrl', detailsCtrl);

    detailsCtrl.$inject = ['$scope', 'detailsService'];

    function detailsCtrl($scope, detailsService) {

        $scope.detail = {};
        $scope.detail.quantity = 0;

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

        $scope.setCreationDate = function (date) {
            console.log('hi');
            $scope.detail.creationDate = date;
        }

        $scope.addDetail = function (detail) {
            console.log(detail);
            return;
            detailsService.addDetail(detail)
                .then(function (response) {
                    //getDetails();
                    console.log('success: ctrl');
                }, function (error) {
                    console.log(error);
                });
        }
    }
})();
