var mainApp = angular.module('MainApp', []);

mainApp.controller('MainCtrl', function ($scope, StorekeeperService) {

    getStorekeepers();

    function getStorekeepers() {
        StorekeeperService.getStorekeepers()
            .then(
            function (response) {
                    console.log(response);
                    $scope.storekeepers = response.data;
                    //console.log($scope.storekeepers);
                }, function (error) {
                    console.log(error);
                });
    };


});

mainApp.factory('StorekeeperService', ['$http', function ($http) {

    var storekeeperService = {};
    storekeeperService.getStorekeepers = function () {
        return $http.get('/Home/GetStorekeepers');
    };
    return storekeeperService;
}]);