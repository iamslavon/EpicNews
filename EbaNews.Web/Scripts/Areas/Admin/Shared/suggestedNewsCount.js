angular.module("suggestedNewsCount", [])
    .controller("suggestedNewsCountController", function ($scope, $http) {

        $scope.count = 0;
        $scope.loading = false;
        $scope.error = false;

        $scope.getStatistics = function() {
            $scope.loading = true;
            var url = window.location.origin + "/mngmnt/statistics/suggestednewscount";
            $http.get(url).then(
                function (response) {
                    $scope.count = response.data;
                    $scope.loading = false;
                },
                function(error) {
                    $scope.error = true;
                });
        };

        $scope.getStatistics();
    })
    .directive("suggestedNewsCount", function () {
        return {
            restrict: "E",
            templateUrl: "/Scripts/Areas/Admin/Shared/suggestedNewsCount.html"
        };
    });