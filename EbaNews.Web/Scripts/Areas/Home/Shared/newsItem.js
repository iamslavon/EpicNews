angular.module("newsItem", ["ngNotify", "angular-clipboard"])
    .controller("newsItemController", function ($scope, clipboard, ngNotify, translate) {

        $scope.strings = translate;

        $scope.showCopyButton = function () {
            return clipboard.supported;
        };

        $scope.copyToClipboard = function (id) {
            var link = window.location.origin + "/news/" + id;
            clipboard.copyText(link);
            ngNotify.set(translate.LinkCopiedToClipboard, "success");
        };

    })
    .directive("newsItem", function () {
        return {
            restrict: "E",
            templateUrl: "/Scripts/Areas/Home/Shared/newsItem.html",
            scope: {
                news: "=data"
            }
        };
    });