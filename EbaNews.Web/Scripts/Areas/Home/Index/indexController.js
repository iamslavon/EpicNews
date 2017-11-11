var app = angular.module("home");

app.controller("indexController",
    function ($scope, $http, ngNotify, clipboard) {
        $scope.loading = {
            page: false,
            lazy: false
        };
        $scope.newsList = [];
        $scope.total = 0;
        $scope.pageSize = 2;

        $scope.startLoading = function (lazy) {
            if (lazy) {
                $scope.loading.lazy = true;
            } else {
                $scope.loading.page = true;
            }
        };

        $scope.stopLoading = function() {
            $scope.loading.lazy = false;
            $scope.loading.page = false;
        };

        $scope.showMoreButton = function() {
            return $scope.newsList.length < $scope.total;
        };

        $scope.showCopyButton = function() {
            return clipboard.supported;
        };

        $scope.copyToClipboard = function (id) {
            var link = window.location.href + "news/" + id;
            clipboard.copyText(link);
            ngNotify.set("Link was copied to clipboard", "success");
        };

        $scope.getNews = function () {
            var request = {
                params: {
                    start: $scope.newsList.length,
                    count: $scope.pageSize
                }
            };

            $http.get("/api/newslist/get", request)
                .then(
                    function(response) {
                        $scope.newsList = $scope.newsList.concat(response.data.Data);
                        $scope.total = response.data.Total;
                        $scope.stopLoading();
                    },
                    function(error) {
                        ngNotify.set("Something went wrong", "error");
                    });
        };

        $scope.loadPage = function() {
            $scope.startLoading();
            $scope.getNews();
        };

        $scope.lazyLoad = function() {
            $scope.startLoading(true);
            $scope.getNews();
        };

        $scope.loadPage();
    });