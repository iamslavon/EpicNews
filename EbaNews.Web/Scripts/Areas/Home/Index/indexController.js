var app = angular.module("home");

app.controller("indexController",
    function ($scope, $http, ngNotify, translate) {
        var classNames = [
            "style-1",
            "style-2",
            "style-3",
            "style-4",
            "style-5"
        ];

        classNames = shuffle(classNames);

        function shuffle(array) {
            var currentIndex = array.length, temporaryValue, randomIndex;

            // While there remain elements to shuffle...
            while (0 !== currentIndex) {

                // Pick a remaining element...
                randomIndex = Math.floor(Math.random() * currentIndex);
                currentIndex -= 1;

                // And swap it with the current element.
                temporaryValue = array[currentIndex];
                array[currentIndex] = array[randomIndex];
                array[randomIndex] = temporaryValue;
            }

            return array;
        }

        $scope.getClassName = function (index) {
            return classNames[index % 5];
        };

        $scope.loading = {
            page: false,
            lazy: false
        };
        $scope.newsList = [];
        $scope.total = 0;
        $scope.pageSize = 5;

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
                        ngNotify.set(translate.SomethingWentWrong, "error");
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