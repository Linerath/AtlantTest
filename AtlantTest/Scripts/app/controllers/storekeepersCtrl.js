(function () {
    'use strict';

    angular
        .module('mainApp')
        .controller('storekeepersCtrl', storekeepersCtrl);

    storekeepersCtrl.$inject = ['$scope', 'storekeepersService', 'paginationService'];

    function storekeepersCtrl($scope, storekeepersService, paginationService) {

        getStorekeepers();

        $scope.storekeeper = {};

        $scope.pageInfo = {};
        $scope.setPage = setPage;

        var inited = false;

        function initPage() {
            setPage(1);
            inited = true;
        };

        function getStorekeepers(refresh = false) {
            storekeepersService.getStorekeepers()
                .then(
                    function (response) {
                        $scope.storekeepersData = response.data;
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

        $scope.addStorekeeper = function (storekeeper) {
            storekeepersService.addStorekeeper(storekeeper)
                .then(
                    function (response) {
                        getStorekeepers(true);
                    }, function (error) {
                        console.log(error);
                    });
        };

        $scope.deleteStorekeeper = function (storekeeperId) {
            storekeepersService.deleteStorekeeper(storekeeperId)
                .then(
                    function (response) {
                        getStorekeepers(true);
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

            $scope.pageInfo = paginationService.getPageInfo($scope.storekeepersData.length, page);
            $scope.pagedStorekeepersData = $scope.storekeepersData.slice($scope.pageInfo.startIndex, $scope.pageInfo.endIndex + 1);
        };
    }
})();
