angular
    .module("home",
    ["ngNotify", "angular-clipboard", "newsItem", "langSelector", "translateService", "angularModalService", "duScroll"])
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
        function($scope, $document, ModalService) {

            $scope.openAboutUsModal = function() {
                ModalService.showModal({
                    templateUrl: "/Scripts/Areas/Home/Shared/aboutUsModal.html",
                    controller: "aboutUsController"
                });
            };

            $scope.openSuggestNewsModal = function () {
                ModalService.showModal({
                    templateUrl: "/Scripts/Areas/Home/Shared/suggestNewsModal.html",
                    controller: "suggestNewsController"
                });
            };

            $scope.scrollTop = function () {
                $document.scrollTopAnimated(0);
            };

            $scope.showGoTopButton = function () {
                return window.scrollY > 1000;
            };

            $document.on('scroll', function () {
                $scope.$apply(function() {
                    $scope.pixelsScrolled = window.scrollY;
                });
            });
        }
    );