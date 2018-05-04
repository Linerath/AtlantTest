var detailsApp = angular.module('DetailsApp', []);

detailsApp.controller('MainCtrl', function ($scope, DetailsService) {

    getDetails();

    function getDetails() {
        DetailsService.getDetails()
            .then(
                function (response) {
                    $scope.details = response.data;
                    console.log($scope.details);
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