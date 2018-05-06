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
                        var data = JSON.parse(response.data);
                        $scope.allStorekeepers = data.Storekeepers;
                        var allDetailsData = data.DetailsData
                        for (var key in allDetailsData) {
                            allDetailsData[key].Detail.CreationDate = new Date(allDetailsData[key].Detail.CreationDate).toLocaleString();
                            if (allDetailsData[key].Detail.DeleteDate != null)
                                allDetailsData[key].Detail.DeleteDate = new Date(allDetailsData[key].Detail.DeleteDate).toLocaleString();
                        }
                        $scope.allDetailsData = allDetailsData;
                    }, function (error) {
                        console.log(error);
                    });
        }

        $scope.setCreationDate = function (date) {
            $scope.detail.creationDate = date;
        }

        $scope.addDetail = function (detail) {
            if (!detail.storekeeperId || detail.storekeeperId.toString().trim() == '')
                return;
            detailsService.addDetail(detail)
                .then(function (response) {
                    getDetails();
                }, function (error) {
                    console.log(error);
                });
        }
    }
})();
