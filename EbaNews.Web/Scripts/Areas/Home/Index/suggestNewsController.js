var app = angular.module("home");

app.controller("suggestNewsController",
    function ($scope, $http, ngNotify, translate) {
        $scope.news = {};

        $scope.suggest = function() {
            $http.post("/api/news/suggest", $scope.news)
                .then(
                    function() {
                        window.$("#suggest-modal").modal("hide");
                        ngNotify.set(translate.YourNewsSuccessfullySuggested, "success");
                    },
                    function(error) {
                        ngNotify.set(translate.SomethingWentWrong, "error");
                    });
        };
    });