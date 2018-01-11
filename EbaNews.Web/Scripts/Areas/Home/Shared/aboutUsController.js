angular.module("home")
    .controller("aboutUsController",
        function($scope, close) {
            $scope.closeModal = function() {
                close();
            };
        });