angular.module("newsItem", ["ngNotify", "angular-clipboard", "720kb.socialshare"])
    .controller("newsItemController", function ($scope, clipboard, ngNotify, translate, Socialshare) {

        $scope.strings = translate;

        $scope.showCopyButton = function() {
            return clipboard.supported;
        };

        $scope.getNewsLink = function(id) {
            return window.location.origin + "/news/" + id;
        };

        $scope.copyToClipboard = function(id) {
            var link = $scope.getNewsLink(id);
            clipboard.copyText(link);
            ngNotify.set(translate.LinkCopiedToClipboard, "success");
        };

        $scope.shareToTwitter = function(news) {
            Socialshare.share({
                'provider': "twitter",
                'attrs': {
                    'socialshareText': news.Title,
                    'socialshareHashtags': "epicnews",
                    'socialshareUrl': $scope.getNewsLink(news.Id),
                    'socialsharePopupHeight': "400",
                    'socialsharePopupWidth': "600"
                }
            });
        };

        $scope.shareToTelegram = function (news) {
            Socialshare.share({
                'provider': "telegram",
                'attrs': {
                    'socialshareText': news.Title,
                    'socialshareUrl': $scope.getNewsLink(news.Id),
                    'socialsharePopupHeight': "400",
                    'socialsharePopupWidth': "600"
                }
            });
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