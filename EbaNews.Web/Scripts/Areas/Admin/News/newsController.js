var app = angular.module("admin");

app.controller("newsController", function ($scope, $http, ngNotify) {
    $scope.newsList = [];
    $scope.languages = [];
    $scope.total = 0;
    $scope.page = 1;
    $scope.pageSize = 10;
    $scope.loading = false;
    $scope.newNews = {};
    $scope.editingNews = {};

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

    $scope.switchOnlineStatus = function(news) {
        var request = {
            newsId: news.Id,
            online: news.Online
        };

        $http.post("/mngmnt/news/online/switch", request).then(
            function(response) {

            },
            function(error) {
                ngNotify.set(error.statusText, "error");
            });
    };

    $scope.getNews = function() {
        $scope.startLoading();

        var request = {
            params: {
                page: $scope.page,
                pageSize: $scope.pageSize
            }
        };

        $http.get("/mngmnt/news/get", request)
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

    $scope.openAddNewsModal = function () {
        $scope.newNews.Language = $scope.languages[1];
        $("#add-modal").modal("show");
    };

    $scope.addNews = function() {
        $http.post("/mngmnt/news/add", $scope.newNews)
            .then(
                function(response) {
                    window.$("#add-modal").modal("hide");
                    $scope.newNews = {};
                    $scope.getNews();
                    ngNotify.set("News has added", "success");
                },
                function(error) {
                    ngNotify.set(error.statusText, "error");
                });
    };

    $scope.openEditModal = function (news) {
        angular.copy(news, $scope.editingNews);
        $scope.editingNews.Language = $scope.languages
            .find(language => language.Id === news.Language.Id);
        window.$("#edit-modal").modal("show");
    };

    $scope.editNews = function () {
        var formatedDate = moment($scope.editingNews.PublicationDate).format();
        $scope.editingNews.PublicationDate = formatedDate;

        $http.post("/mngmnt/news/edit", $scope.editingNews)
            .then(
                function() {
                    window.$("#edit-modal").modal("hide");
                    $scope.getNews();
                    ngNotify.set("Saved", "success");
                },
                function(error) {
                    ngNotify.set(error.statusText, "error");
                });
    };

    $scope.deleteNews = function (id) {
        if (confirm("Are you sure?")) {
            var data = {
                id: id
            };

            $http.post("/mngmnt/news/delete", data)
                .then(
                    function() {
                        $scope.getNews();
                    },
                    function(error) {
                        ngNotify.set(error.statusText, "error");
                    });
        }
    };

    $scope.getLanguages = function () {
        $http.get("/mngmnt/languages/get")
            .then(
                function(response) {
                    $scope.languages = response.data;
                },
                function(error) {
                    ngNotify.set(error.statusText, "error");
                });
    };

    $scope.getNews();
    $scope.getLanguages();
});