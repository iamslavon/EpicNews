var app = angular.module("home");

app.controller("suggestNewsController",
    function ($scope, close, $http, ngNotify, translate) {
        $scope.news = {};

        $scope.strings = {
            SuggestNews: translate.SuggestNews,
            Suggest: translate.Suggest,
            InsertTheLink: translate.InsertTheLink
        };

        $scope.loading = false;

        $scope.startLoading = function() {
            $scope.loading = true;
        }

        $scope.stopLoading = function () {
            $scope.loading = false;
        }

        $scope.suggest = function() {
            $scope.startLoading();
            $http.post("/api/news/suggest", $scope.news)
                .then(
                    function() {
                        $scope.stopLoading();
                        ngNotify.set(translate.YourNewsSuccessfullySuggested, "success");
                        close();
                    },
                    function(error) {
                        $scope.stopLoading();
                        ngNotify.set(translate.SomethingWentWrong, "error");
                    });
        };

        $scope.closeModal = function(event) {
            if (event && event.target !== event.currentTarget) return;
            close();
        };
    });