(function () {
    'use strict';

    angular
        .module('mainApp')
        .controller('detailsCtrl', detailsCtrl);

    detailsCtrl.$inject = ['$scope', 'detailsService', 'paginationService'];

    function detailsCtrl($scope, detailsService, paginationService) {

        getDetails();

        $scope.detail = {
            quantity: 1
        };

        $scope.pageInfo = {};
        $scope.setPage = setPage;

        var inited = false;

        function initPage() {
            setPage(1);
            inited = true;
        };

        function getDetails(refresh = false) {
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
                        if (!inited) {
                            initPage();
                        }
                        if (refresh) {
                            $scope.setPage($scope.pageInfo.currentPage);
                        }
                    }, function (error) {
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
                    getDetails(true);
                }, function (error) {
                    console.log(error);
                });
        };

        $scope.deleteDetail = function (detailId) {
            detailsService.deleteDetail(detailId)
                .then(function (response) {
                    getDetails(true);
                }, function (error) {
                    console.log(error);
                });
        };

        $scope.markDetailDeleted = function (detailId, index) {
            detailsService.markDetailDeleted(detailId)
                .then(function (response) {
                    var detailIndex = ($scope.pageInfo.currentPage - 1) * $scope.pageInfo.pageSize + index;
                    refreshDetail(detailId, detailIndex);
                }, function (error) {
                    console.log(error);
                });
        };

        $scope.addDetailQuantity = function (detailId, quantity, index) {
            $scope.block = true;
            detailsService.addDetailQuantity(detailId, quantity)
                .then(
                    function (response) {
                        var detailIndex = ($scope.pageInfo.currentPage - 1) * $scope.pageInfo.pageSize + index;
                        refreshDetail(detailId, detailIndex);
                        $scope.block = false;
                    }, function (error) {
                        console.log(error);
                    });
        };

        function refreshDetail(detailId, detailIndex) {
            var detail = detailsService.getDetail(detailId)
                .then(
                    function (response) {
                        var dt = JSON.parse(response.data);
                        dt.CreationDate = new Date(dt.CreationDate).toLocaleString();
                        if (dt.DeleteDate !== null)
                            dt.DeleteDate = new Date(dt.DeleteDate).toLocaleString();
                        $scope.allDetailsData[detailIndex].Detail = dt;
                    }, function (error) {
                        console.log(error);
                    });
        };

        function setPage(page) {
            if (page < 1) {
                page = 1;
            }
            if (page > $scope.pageInfo.totalPages) {
                page = $scope.pageInfo.totalPages;
            }

            $scope.pageInfo = paginationService.getPageInfo($scope.allDetailsData.length, page);
            $scope.pagedDetailsData = $scope.allDetailsData.slice($scope.pageInfo.startIndex, $scope.pageInfo.endIndex + 1);
        };
    }
})();
