var storekeepersApp = angular.module('StorekeepersApp', []);

storekeepersApp.controller('MainCtrl', function ($scope, StorekeepersService) {

    $scope.getStorekeepers = function() {
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

storekeepersApp.factory('StorekeepersService', ['$http', function ($http) {

    var storekeepersService = {};
    storekeepersService.getStorekeepers = function () {
        return $http.get('/Storekeepers/GetAll');
    };
    return storekeepersService;
}]);