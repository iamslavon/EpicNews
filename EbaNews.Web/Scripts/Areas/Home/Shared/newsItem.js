angular.module("newsItem", [])
    .controller("newsItemController", ["$scope", function ($scope) {
        
    }])
    .directive("newsItem", function () {
        return {
            restrict: "E",
            templateUrl: "/Scripts/Areas/Home/Shared/newsItem.html"
        };
    });