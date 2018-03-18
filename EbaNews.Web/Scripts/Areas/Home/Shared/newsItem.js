angular.module("newsItem", ["ngNotify", "angular-clipboard", "720kb.socialshare"])
    .controller("newsItemController", function ($scope, clipboard, ngNotify, translate, Socialshare, $http) {
        $scope.strings = translate;

        $scope.showCopyButton = function() {
            return clipboard.supported;
        };

        $scope.getNewsLink = function(id) {
            return window.location.origin + "/news/" + id;
        };

        $scope.convertDate = function (date) {
            return moment(date).format("DD.MM.YYYY");
        };

        $scope.copyToClipboard = function(id) {
            var link = $scope.getNewsLink(id);
            clipboard.copyText(link);
            ngNotify.set(translate.LinkCopiedToClipboard, "success");
        };

        $scope.getTitleClass = function(title) {
            if (title.length < 60) return "title-big";
            if (title.length > 90) return "title-small";
            return "title-medium";
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

            $scope.incrementShareCount(news.Id);
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

            $scope.incrementShareCount(news.Id);
        };

        $scope.shareToFacebook = function (news) {
            Socialshare.share({
                'provider': "facebook",
                'attrs': {
                    'socialshareQuote': news.Title,
                    'socialshareUrl': $scope.getNewsLink(news.Id),
                    'socialshareHashtags': "epicnews",
                    'socialsharePopupHeight': "400",
                    'socialsharePopupWidth': "600"
                }
            });

            $scope.incrementShareCount(news.Id);
        };

        $scope.incrementShareCount = function (id) {
            var url = window.location.origin + "/api/news/shares/inc?id=" + id;
            $http.get(url);
        };
    })
    .directive("newsItem", function () {
        return {
            restrict: "E",
            templateUrl: "/Scripts/Areas/Home/Shared/newsItem.html",
            scope: {
                news: "=data",
                styleName: "=?"
            },
            link: function (scope, element, attrs) {
                if (window.angular.isUndefined(scope.styleName)) {
                    scope.styleName = "style-" + Math.floor(Math.random() * 5 + 1);
                    scope.fullMode = true;
                } else {
                    scope.fullMode = false;
                }
            }
        };
    });