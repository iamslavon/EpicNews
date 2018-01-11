angular.module("langSelector", ["ngCookies"])
    .controller("langSelectorController", function ($scope, $cookies) {
        $scope.language = "";

        $scope.onLangSelect = function () {
            var url = window.location.origin + "/language/change?language=" + $scope.language + "&returnUrl=" + window.location.href;
            window.location.href = url;
        };

        $scope.getCurrentLanguage = function() {
            $scope.language = $cookies.get("EpicNews_culture");
        };

        $scope.getCurrentLanguage();
    })
    .directive("langSelector", function () {
        return {
            restrict: "E",
            templateUrl: "/Scripts/Areas/Home/Shared/langSelector.html",
            scope: {
                
            },
            link: function (scope, element, attrs) {
                
            }
        };
    });