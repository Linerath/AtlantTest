var detailsApp = angular.module('DetailsApp', []);

detailsApp.controller('MainCtrl', function ($scope, DetailsService) {

    $scope.getDetails = function() {
        DetailsService.getDetails()
            .then(
                function (response) {
                    $scope.detailsData = response.data;
                }, function (error) {
                    console.log(error);
                });
    };
});

detailsApp.factory('DetailsService', ['$http', function ($http) {

    var detailsService = {};
    detailsService.getDetails = function () {
        return $http.get('/Details/GetAll');
    };
    return detailsService;
}]);