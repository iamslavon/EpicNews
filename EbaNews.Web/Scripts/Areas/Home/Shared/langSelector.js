angular.module("langSelector", ["ngCookies"])
    .controller("langSelectorController", function ($scope, $cookies) {
        $scope.languages = [
            {
                culture: "en",
                text: "EN"
            },
            {
                culture: "ru",
                text: "RU"
            },
            {
                culture: "uk",
                text: "UA"
            }
        ];

        $scope.language = {};
        $scope.opened = false;

        $scope.langSelect = function (lang) {
            var url = window.location.origin + "/language/change?language=" + lang + "&returnUrl=" + window.location.href;
            window.location.href = url;
        };

        $scope.getLangOptions = function() {
            return $scope.languages.filter(function(lang) {
                return lang.culture !== $scope.language.culture;
            });
        };

        $scope.getCurrentLanguage = function() {
            var culture = $cookies.get("EpicNews_culture");

            $scope.language = $scope.languages.filter(function (lang) {
                return lang.culture === culture;
            })[0];
        };

        $scope.getCurrentLanguage();

        $scope.open = function() {
            $scope.opened = !$scope.opened;
        };

        $scope.close = function () {
            $scope.opened = false;
        };
    })
    .directive("langSelector", function () {
        return {
            restrict: "E",
            templateUrl: "/Scripts/Areas/Home/Shared/langSelector.html"
        };
    });