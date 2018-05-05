var mainApp = angular.module('MainApp', []);

mainApp.controller('StorekeepersCtrl', function ($scope, StorekeepersService) {

    $scope.getStorekeepers = function () {
        StorekeepersService.getStorekeepers()
            .then(
                function (response) {
                    $scope.storekeepersData = response.data;
                    console.log($scope.storekeepersData);
                }, function (error) {
                    console.log(error);
                });
    };


});

mainApp.controller('DetailsCtrl', function ($scope, DetailsService) {

    $scope.getDetails = function () {
        DetailsService.getDetails()
            .then(
                function (response) {
                    $scope.detailsData = JSON.parse(response.data);
                    console.log($scope.detailsData);
                }, function (error) {
                    console.log(error);
                });
    };
});

mainApp.factory('StorekeepersService', ['$http', function ($http) {

    var storekeepersService = {};
    storekeepersService.getStorekeepers = function () {
        return $http.get('/Storekeepers/GetAll');
    };
    return storekeepersService;
}]);

mainApp.factory('DetailsService', ['$http', function ($http) {

    var detailsService = {};
    detailsService.getDetails = function () {
        return $http.get('/Details/GetAll');
    };
    return detailsService;
}]);