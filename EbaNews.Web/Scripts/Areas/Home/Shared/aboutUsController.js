angular.module("home")
    .controller("aboutUsController",
    function ($scope, close, translate) {
        $scope.strings = {
            title: translate.AboutUsPopupTitle,
            text: translate.AboutUsPopupText
        };

        $scope.closeModal = function() {
                close();
            };
        });