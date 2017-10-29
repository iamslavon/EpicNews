var app = angular.module("home");

app.controller("suggestNewsController",
    function ($scope, $http, ngNotify) {
        $scope.news = {};

        $scope.suggest = function() {
            $http.post("/api/news/suggest", $scope.news)
                .then(
                    function() {
                        window.$("#suggest-modal").modal("hide");
                        ngNotify.set("Your news successfully suggested", "success");
                    },
                    function(error) {
                        ngNotify.set("Error. Something went wrong", "error");
                    });
        };
    });