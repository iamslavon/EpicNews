var app = angular.module("admin");

app.controller("suggestedNewsController", function ($scope, $http, ngNotify) {
    $scope.newsList = [];
    $scope.languages = [];
    $scope.total = 0;
    $scope.page = 1;
    $scope.pageSize = 10;
    $scope.loading = false;
    $scope.approvingNews = {};

    $scope.totalPages = function () {
        return Math.ceil($scope.total / $scope.pageSize);
    };

    $scope.pages = function () {
        return new Array($scope.totalPages());
    };

    $scope.convertDate = function (date) {
        return moment(date).format("DD.MM.YYYY [-] HH:mm");
    };

    $scope.startLoading = function () {
        $scope.loading = true;
    };

    $scope.stopLoading = function () {
        $scope.loading = false;
    };

    $scope.setPage = function (data) {
        $scope.page = data;
        $scope.getNews();
    };

    $scope.getNews = function () {
        $scope.startLoading();

        var request = {
            params: {
                page: $scope.page,
                pageSize: $scope.pageSize
            }
        };

        $http.get("/mngmnt/news/suggested/get", request)
            .then(
                function(response) {
                    $scope.newsList = response.data.Data;
                    $scope.total = response.data.Total;
                    $scope.stopLoading();
                },
                function(error) {
                    ngNotify.set(error.statusText, "error");
                });
    };

    $scope.declineNews = function (id) {
        if (confirm("Are you sure?")) {
            var data = {
                id: id
            };

            $http.post("/mngmnt/news/suggested/decline", data)
                .then(
                    function() {
                        $scope.getNews();
                    },
                    function(error) {
                        ngNotify.set(error.statusText, "error");
                    });
        }
    };

    $scope.openApproveModal = function (news) {
        $scope.getLanguages();
        angular.copy(news, $scope.approvingNews);
        window.$("#approve-modal").modal("show");
    };

    $scope.approveNews = function () {
        var data = {
            Id: $scope.approvingNews.Id,
            LanguageId: $scope.approvingNews.Language.Id,
            Title: $scope.approvingNews.Title,
            Text: $scope.approvingNews.Text
        };

        $http.post("/mngmnt/news/suggested/approve", data)
            .then(
                function() {
                    window.$("#approve-modal").modal("hide");
                    $scope.getNews();
                    $scope.approvingNews = {};
                },
                function(error) {
                    ngNotify.set(error.statusText, "error");
                });
    };

    $scope.getLanguages = function () {
        if ($scope.languages.length === 0) {
            $http.get("/mngmnt/languages/get")
                .then(
                    function(response) {
                        $scope.languages = response.data;
                    },
                    function(error) {
                        ngNotify.set(error.statusText, "error");
                    });
        }
    };

    $scope.getNews();
});