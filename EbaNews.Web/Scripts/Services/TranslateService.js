angular.module("translateService", [])
    .service("translate",
        function($http) {
            var self = this;

            self.init = function() {
                $http.get(window.location.origin + "/localizedstrings/get")
                    .then(function(response) {
                        Object.assign(self, response.data);
                    });
            };

            this.init();
        });