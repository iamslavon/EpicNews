angular
    .module("home",
        ["ngNotify", "angular-clipboard", "newsItem", "langSelector", "translateService", "angularModalService"])
    .run(function(ngNotify) {
            ngNotify.config({
                theme: "pure",
                position: "bottom",
                duration: 5000,
                sticky: false,
                button: true,
                html: false
            });
        }
    )
    .controller("mainController",
        function($scope, $http, ngNotify, translate, ModalService) {

            $scope.openAboutUsModal = function() {
                ModalService.showModal({
                    templateUrl: "/Scripts/Areas/Home/Shared/aboutUsModal.html",
                    controller: "aboutUsController",
                    bodyClass: "about-active"
                });
            };

            $scope.openSuggestNewsModal = function () {
                ModalService.showModal({
                    templateUrl: "/Scripts/Areas/Home/Shared/suggestNewsModal.html",
                    controller: "suggestNewsController",
                    bodyClass: "suggest-active"
                });
            };
        }
    );