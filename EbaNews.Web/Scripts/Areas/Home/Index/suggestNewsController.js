var app = angular.module("home");

app.controller("suggestNewsController",
    function ($scope, $http) {
        $scope.news = {};

        $scope.suggest = function() {
            $http.post("/api/news/suggest", $scope.news)
                .then(function() {
                        $("#suggest-modal").modal("hide");
                    },
                    function(error) {
                        console.log(error);
                    });
        };
    });