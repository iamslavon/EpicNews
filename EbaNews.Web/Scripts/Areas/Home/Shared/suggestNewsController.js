var app = angular.module("home");

app.controller("suggestNewsController",
    function ($scope, close, $http, ngNotify, translate) {
        $scope.news = {};

        $scope.suggest = function() {
            $http.post("/api/news/suggest", $scope.news)
                .then(
                    function() {
                        ngNotify.set(translate.YourNewsSuccessfullySuggested, "success");
                        close();
                    },
                    function(error) {
                        ngNotify.set(translate.SomethingWentWrong, "error");
                    });
        };

        $scope.closeModal = function() {
            close();
        };
    });