(function () {
    'use strict';

    angular
        .module('mainApp')
        .controller('detailsCtrl', detailsCtrl);

    detailsCtrl.$inject = ['$scope', 'detailsService'];

    function detailsCtrl($scope, detailsService) {

        $scope.detail = {};
        $scope.detail.quantity = 1;

        getDetails();

        function getDetails() {
            detailsService.getDetails()
                .then(
                    function (response) {
                        var data = JSON.parse(response.data);
                        $scope.allStorekeepers = data.Storekeepers;
                        var allDetailsData = data.DetailsData;
                        for (var key in allDetailsData) {
                            allDetailsData[key].Detail.CreationDate = new Date(allDetailsData[key].Detail.CreationDate).toLocaleString();
                            if (allDetailsData[key].Detail.DeleteDate !== null)
                                allDetailsData[key].Detail.DeleteDate = new Date(allDetailsData[key].Detail.DeleteDate).toLocaleString();
                        }
                        $scope.allDetailsData = allDetailsData;
                    }, function (error) {
                        console.log(error);
                    });
        };

        $scope.getDetail = function (detailId) {
            detailsService.getDetail()
                .then(
                    function (response) {
                        console.log(response);
                    },
                    function (error) {
                        console.log(error);
                    });
        };

        $scope.setCreationDate = function (date) {
            $scope.detail.creationDate = date;
        };

        $scope.addDetail = function (detail) {
            if (!detail.storekeeperId || detail.storekeeperId.toString().trim() === '')
                return;
            detailsService.addDetail(detail)
                .then(function (response) {
                    getDetails();
                }, function (error) {
                    console.log(error);
                });
        };

        $scope.deleteDetail = function (detaidId) {
            detailsService.deleteDetail(detaidId)
                .then(function (response) {
                    getDetails();
                }, function (error) {
                    console.log(error);
                });
        };

        $scope.markDetailDeleted = function (detaidId) {
            detailsService.markDetailDeleted(detaidId)
                .then(function (response) {
                    getDetails();
                }, function (error) {
                    console.log(error);
                });
        };

        $scope.addDetailQuantity = function (detailId, quantity, index) {
            if ($scope.allDetailsData[index].Detail.Quantity <= 1 && quantity < 0)
                return;
            detailsService.addDetailQuantity(detailId, quantity)
                .then(
                    function (response) {
                        var detail = detailsService.getDetail(detailId).
                            then(
                                function (resp) {
                                    var dt = JSON.parse(resp.data);
                                    dt.CreationDate = new Date(dt.CreationDate).toLocaleString();
                                    if (dt.DeleteDate !== null)
                                        dt.DeleteDate = new Date(dt.DeleteDate).toLocaleString();
                                    $scope.allDetailsData[index].Detail = dt;
                                }, function (err) {
                                    console.log(err);
                                });
                    }, function (error) {
                        console.log(error);
                    });
        };
    }
})();
