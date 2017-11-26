angular.module("newsCount", [])
    .controller("newsCountController", function ($scope, $http) {

        $scope.statistics = [];
        $scope.loading = false;
        $scope.error = false;

        $scope.getStatistics = function() {
            $scope.loading = true;
            var url = window.location.origin + "/mngmnt/statistics/newsbylanguages";
            $http.get(url).then(
                function (response) {
                    $scope.statistics = response.data;
                    $scope.loading = false;
                },
                function(error) {
                    $scope.error = true;
                });
        };

        $scope.getStatistics();
    })
    .directive("newsCount", function () {
        return {
            restrict: "E",
            templateUrl: "/Scripts/Areas/Admin/Shared/newsCount.html",
            scope: {
                
            },
            link: function (scope, element, attrs) {
                
            }
        };
    });