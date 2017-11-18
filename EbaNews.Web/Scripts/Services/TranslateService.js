angular.module("translateService", [])
    .service("translate",
        function($http) {
            var self = this;

            self.init = function() {
                $http.get("localizedstrings/get")
                    .then(function(response) {
                        Object.assign(self, response.data);
                    });
            };

            this.init();
        });