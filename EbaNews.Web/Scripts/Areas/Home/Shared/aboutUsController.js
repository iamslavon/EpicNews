angular.module("home")
    .controller("aboutUsController",
    function ($scope, close, translate) {
        $scope.strings = {
            title: translate.AboutUsPopupTitle,
            text: translate.AboutUsPopupText,
            contact: translate.Contact
        };

        $scope.closeModal = function(event) {
            if (event && event.target !== event.currentTarget) return;
            close();
        };
    });