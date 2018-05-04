var storekeepersApp = angular.module('StorekeepersApp', []);

storekeepersApp.controller('MainCtrl', function ($scope, StorekeepersService) {

    getStorekeepers();

    function getStorekeepers() {
        StorekeepersService.getStorekeepers()
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

storekeepersApp.factory('StorekeepersService', ['$http', function ($http) {

    var storekeepersService = {};
    storekeepersService.getStorekeepers = function () {
        return $http.get('/Storekeepers/GetAll');
    };
    return storekeepersService;
}]);