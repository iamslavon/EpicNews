var app = angular.module("admin");

app.controller("usersController", function ($scope, $http, ngNotify) {
    $scope.users = [];
    $scope.loading = false;

    $scope.startLoading = function () {
        $scope.loading = true;
    };

    $scope.stopLoading = function () {
        $scope.loading = false;
    };

    $scope.isInRole = function (user, role) {
        return user.Roles.indexOf(role) !== -1;
    };

    $scope.getUsers = function () {
        $scope.startLoading();
        $http.get("/mngmnt/users/get")
            .then(
                function(response) {
                    $scope.users = response.data;
                    $scope.stopLoading();
                },
                function(error) {
                    ngNotify.set(error.statusText, "error");
                });
    };

    $scope.switchAdminRole = function (user) {
        $scope.switchRole(user, "admin");
    };

    $scope.switchOwnerRole = function (user) {
        $scope.switchRole(user, "owner");
    };

    $scope.switchRole = function (user, role) {
        var data = {
            UserId: user.Id,
            Role: role
        };

        $http.post("/mngmnt/users/role/switch", data)
            .then(
                function(response) {
                    user.Roles = response.data;
                },
                function(error) {
                    ngNotify.set(error.statusText, "error");
                });
    };

    $scope.getUsers();
});